using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HorelBusinessService.ImplementationsBD
{
    public class OrderService : IOrderService
    {
        private readonly AbstractDbContext context;

        public OrderService(AbstractDbContext context)
        {
            this.context = context;
        }

        public async System.Threading.Tasks.Task AddElement(OrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    TimeSpan diff1 = model.DepartureDate.Subtract(model.ArrivalDate);
                    int days = diff1.Days;

                    var element = new Order
                    {
                        UserId = model.UserId,
                        ArrivalDate = model.ArrivalDate,
                        DepartureDate = model.DepartureDate,
                        OrderStatus = OrderStatus.Начат
                    };
                    context.Orders.Add(element);
                    await context.SaveChangesAsync();

                    var groupServices = model.ServiceOrders.GroupBy(rec => rec.ServiceId).Select(rec => new ServiceOrderBindingModel
                    {
                        ServiceId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    foreach (var groupService in groupServices)
                    {
                        context.ServiceOrders.Add(new ServiceOrder
                        {
                            OrderId = element.Id,
                            Count = groupService.Count,
                            Price = context.Services.Where(rec => rec.Id == groupService.ServiceId).FirstOrDefault().Price,
                            ServiceId = groupService.ServiceId,
                        });
                    }
                    await context.SaveChangesAsync();

                    var groupRooms = model.RoomOrders.GroupBy(rec => rec.RoomId).Select(rec => new RoomOrderBindingModel
                    {
                        RoomId = rec.Key
                    });
                    foreach (var groupRoom in groupRooms)
                    {
                        context.RoomOrders.Add(new RoomOrder
                        {
                            OrderId = element.Id,
                            ArrivalDate = model.ArrivalDate,
                            DepartureDate = model.DepartureDate,
                            Price = context.Forms.Where(rec => rec.Id == context.Rooms.Where(rec1 => rec1.Id == groupRoom.RoomId).FirstOrDefault().FormId).FirstOrDefault().Price * days,
                            RoomId = groupRoom.RoomId
                        });
                    }

                    await context.SaveChangesAsync();
                    if (model.Payed > 0)
                    {
                        await CreatePayment(new PaymentBindingModel
                        {
                            OrderId = element.Id,
                            Summ = model.Payed,
                            PayType = model.PayType
                        });
                    }

                    //отправка брони на почту
                    await SendPosetitelAccountDoc(new OrderBindingModel
                    {
                        Id = element.Id,
                        FileName = model.FileName
                    });
                    await SendPosetitelAccountXls(new OrderBindingModel
                    {
                        Id = element.Id,
                        FileName = model.FileName
                    });
                    await SaveReservation(new OrderBindingModel
                    {
                        Id = element.Id,
                        FileName = model.FileName + "Бронь" + element.Id + ".pdf",
                        FontPath = model.FontPath
                    });

                    await System.Threading.Tasks.Task.Run(() => transaction.Commit());
                }
                catch (Exception ex)
                {
                    await System.Threading.Tasks.Task.Run(() => transaction.Rollback());
                    throw;
                }
            }
        }

        public async System.Threading.Tasks.Task CreatePayment(PaymentBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.OrderId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.OrderStatus = OrderStatus.Оплачен;
 
            context.Payments.Add(new Payment
            {
                OrderId = model.OrderId,
                Summ = model.Summ,
                DateImplement = DateTime.Now,
                DateCreate = DateTime.Now,
                PayType = model.PayType
            });
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = await context.Orders.FirstOrDefaultAsync(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.ServiceOrders.RemoveRange(
                                            context.ServiceOrders.Where(rec => rec.OrderId == id));
                        context.Orders.Remove(element);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    await System.Threading.Tasks.Task.Run(() => transaction.Commit());
                }
                catch (Exception)
                {
                    await System.Threading.Tasks.Task.Run(() => transaction.Rollback());
                    throw;
                }
            }
        }

        public async Task<OrderViewModel> GetElement(int id)
        {
            Order element = await context.Orders.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                var serviceOrders = await context.ServiceOrders.Where(rec => rec.OrderId == element.Id).Include(rec => rec.Service).Select(rec => new ServiceOrderViewModel
                {
                    Id = rec.Id,
                    ServiceName = rec.Service.ServiceName,
                    Count = rec.Count,
                    Price = rec.Price,
                    Total = rec.Count * rec.Price
                }).ToListAsync();
                var roomOrders = await context.RoomOrders.Where(rec => rec.OrderId == element.Id).Include(rec => rec.Room).Select(rec => new RoomOrderViewModel
                {
                    RoomName = rec.Room.RoomName,
                    FormId = rec.Room.Form.Id,
                    FormName = rec.Room.Form.FormName,
                    Price = rec.Price
                }).ToListAsync();
                var sum = serviceOrders.Select(rec => rec.Total).DefaultIfEmpty(0).Sum();
                var paid = context.Payments.Where(rec => rec.OrderId == element.Id).Select(rec => rec.Summ).DefaultIfEmpty(0).Sum();
                return new OrderViewModel
                {
                    Id = element.Id,
                    UserFIO = context.Users.Where(rec => rec.Id == element.UserId).Select(rec => rec.UserFIO).FirstOrDefault(),
                    UserId = element.UserId,
                    ArrivalDate = element.ArrivalDate.ToLongDateString(),
                    DepartureDate = element.DepartureDate.ToLongDateString(),
                    ServiceOrders = serviceOrders,
                    RoomOrders = roomOrders,
                    OrderStatus = element.OrderStatus.ToString(),
                    Sum = sum,
                    Paid = paid,
                    Pogashenie = sum - paid,
                    PogashenieDate = element.DepartureDate
                };
            }
            throw new Exception("Элемент не найден");
        }

        public async Task<List<OrderViewModel>> GetList()
        {
            return await context.Orders.Include(rec => rec.User)//.Include(rec=>rec.Pays)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    UserFIO = rec.User.UserFIO,
                    Mail = rec.User.UserName,
                    UserId = rec.UserId,
                    ArrivalDate = SqlFunctions.DateName("dd", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("mm", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.ArrivalDate),
                    DepartureDate = SqlFunctions.DateName("dd", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("mm", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DepartureDate),
                    OrderStatus = rec.OrderStatus.ToString(),
                    PogashenieDate = rec.DepartureDate,
                    //Sum = rec.ServiceOrders.Select(r=>r.Price * r.Count).DefaultIfEmpty(0).Sum(),
                    //Paid = rec.Pays.Select(r=>r.Summ).DefaultIfEmpty(0).Sum(),
                    //Credit = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() - rec.Pays.Select(r => r.Summ).DefaultIfEmpty(0).Sum()
                }).ToListAsync();
        }

        public async Task<List<RoomOrderViewModel>> GetListRoomOrder()
        {
            return await context.RoomOrders
                .Select(rec => new RoomOrderViewModel
                {
                    ArrivalDate = rec.ArrivalDate,
                    DepartureDate = rec.DepartureDate,
                    RoomId = rec.RoomId,                    
                    OrderStatus = rec.Order.OrderStatus.ToString(),
                }).ToListAsync();
        }

        public async Task<List<OrderViewModel>> GetList(string clientId)
        {
            return await context.Orders.Where(rec => rec.UserId == clientId).Include(rec => rec.User).Include(rec => rec.ServiceOrders).Include(rec => rec.RoomOrders)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    UserFIO = rec.User.UserFIO,
                    Mail = rec.User.UserName,
                    UserId = rec.UserId,
                    ArrivalDate = SqlFunctions.DateName("dd", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("mm", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.ArrivalDate),
                    DepartureDate = SqlFunctions.DateName("dd", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("mm", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DepartureDate),
                    OrderStatus = rec.OrderStatus.ToString(),
                    PogashenieDate = rec.DepartureDate,
                    Sum = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() + rec.RoomOrders.Select(r => r.Price).DefaultIfEmpty(0).Sum(),
                    Paid = rec.Payments.Select(r => r.Summ).DefaultIfEmpty(0).Sum(),
                    Pogashenie = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() + rec.RoomOrders.Select(r => r.Price).DefaultIfEmpty(0).Sum() - rec.Payments.Select(r => r.Summ).DefaultIfEmpty(0).Sum(),

                    ServiceOrders = rec.ServiceOrders.Select(r => new ServiceOrderViewModel
                    {
                        ServiceName = r.Service.ServiceName,
                        Count = r.Count,
                        Price = r.Price,
                        Total = r.Count * r.Price
                    }).ToList(),
                    RoomOrders = rec.RoomOrders.Select(r => new RoomOrderViewModel
                    {
                        RoomName = r.Room.RoomName,
                        FormId = r.Room.Form.Id,
                        FormName = r.Room.Form.FormName,
                        Price = r.Price
                    }).ToList()

                }).ToListAsync();
        }

        public System.Threading.Tasks.Task UpdElement(OrderBindingModel model)
        {
            throw new NotImplementedException();
        }


                    ////////////////////

        private async System.Threading.Tasks.Task<OrderViewModel> GetOrder(int orderId)
        {
            return await context.Orders.Where(rec => rec.Id == orderId).Include(rec => rec.User).Include(rec => rec.ServiceOrders).Include(rec => rec.RoomOrders)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    Mail = rec.User.UserName,
                    ArrivalDate = SqlFunctions.DateName("dd", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("mm", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.ArrivalDate),
                    DepartureDate = SqlFunctions.DateName("dd", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("mm", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DepartureDate),
                    OrderStatus = rec.OrderStatus.ToString(),
                    Sum = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() + rec.RoomOrders.Select(r => r.Price).DefaultIfEmpty(0).Sum(),
                    ServiceOrders = rec.ServiceOrders.Select(r => new ServiceOrderViewModel
                    {
                        ServiceName = r.Service.ServiceName,
                        Count = r.Count,
                        Price = r.Price,
                        Total = r.Count * r.Price
                    }).ToList(),
                    RoomOrders = rec.RoomOrders.Select(r => new RoomOrderViewModel
                    {
                        RoomName = r.Room.RoomName,
                        FormId = r.Room.Form.Id,
                        FormName = r.Room.Form.FormName,
                        Price = r.Price
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async System.Threading.Tasks.Task SendMail(string mailto, string caption, string message, string path = null)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            SmtpClient stmpClient = null;
            try
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                mailMessage.To.Add(new MailAddress(mailto));
                mailMessage.Subject = caption;
                mailMessage.Body = message;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                if (path != null)
                {
                    mailMessage.Attachments.Add(new Attachment(path));
                }

                stmpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"].Split('@')[0],
                    ConfigurationManager.AppSettings["MailPassword"])
                };
                await stmpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mailMessage.Dispose();
                mailMessage = null;
                stmpClient = null;
            }
        }

        public async System.Threading.Tasks.Task SendPosetitelAccountXls(OrderBindingModel model)
        {
            OrderViewModel zakaz = await GetOrder(model.Id);

            var ms = (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
            model.FileName += zakaz.Mail + "_Account_№" + zakaz.Id + "_" + ms + ".xls";
            var excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (File.Exists(model.FileName))
                {
                    excel.Workbooks.Open(model.FileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(model.FileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;
                //Получаем ссылку на лист
                var excelworksheet = (Worksheet)excelsheets.get_Item(1);
                //очищаем ячейки
                excelworksheet.Cells.Clear();
                //настройки страницы
                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;

                Microsoft.Office.Interop.Excel.Range excelcells = excelworksheet.get_Range("A1", "E1");
                //объединяем их
                excelcells.Merge(Type.Missing);
                //задаем текст, настройки шрифта и ячейки
                excelcells.Font.Bold = true;
                excelcells.Value2 = "Бронь № " + zakaz.Id + ". Въезд " + zakaz.ArrivalDate + "- Выезд " + zakaz.DepartureDate;
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                if (zakaz.ServiceOrders != null)
                {
                    excelcells = excelworksheet.get_Range("A3", "A3");
                    //выделение таблицы
                    var excelTable =
                                excelworksheet.get_Range(excelcells,
                                            excelcells.get_Offset(zakaz.ServiceOrders.Count() + zakaz.RoomOrders.Count(), 4));
                    excelTable.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    excelTable.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    excelTable.HorizontalAlignment = Constants.xlCenter;
                    excelTable.VerticalAlignment = Constants.xlCenter;
                    excelTable.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                                            Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                                            Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                                            1);

                    var excelHead =
                                excelworksheet.get_Range(excelcells,
                                            excelcells.get_Offset(0, 4));
                    excelHead.Font.Bold = true;

                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = "№";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.ColumnWidth = 5;
                    excelcells.Value2 = "Наименование";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.ColumnWidth = 20;
                    excelcells.Value2 = "Кол-во";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = "Цена";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = "Сумма";
                    excelcells = excelcells.get_Offset(1, -4);

                    for (int i = 0; i < zakaz.ServiceOrders.Count; i++)
                    {
                        excelcells.ColumnWidth = 5;
                        excelcells.Value2 = (i + 1);
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 20;
                        excelcells.Value2 = zakaz.ServiceOrders[i].ServiceName;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = zakaz.ServiceOrders[i].Count;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = zakaz.ServiceOrders[i].Price;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = zakaz.ServiceOrders[i].Total;
                        excelcells = excelcells.get_Offset(1, -4);
                    }
                    for (int i = 0; i < zakaz.RoomOrders.Count; i++)
                    {
                        excelcells.ColumnWidth = 5;
                        excelcells.Value2 = (i + 1);
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 20;
                        excelcells.Value2 = zakaz.RoomOrders[i].FormName;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = 1;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = zakaz.RoomOrders[i].Price;
                        excelcells = excelcells.get_Offset(0, 1);
                        excelcells.ColumnWidth = 15;
                        excelcells.Value2 = zakaz.RoomOrders[i].Price;
                        excelcells = excelcells.get_Offset(1, -4);
                    }
                    excelcells = excelcells.get_Offset(0, 3);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = "Итого:";
                    excelcells = excelcells.get_Offset(0, 1);
                    excelcells.ColumnWidth = 15;
                    excelcells.Value2 = zakaz.Sum;
                }
                //сохраняем
                excel.Workbooks[1].Save();
                excel.Workbooks[1].Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //закрываем
                excel.Quit();
            }
            await SendMail(zakaz.Mail, "Бронь", "Номер брони № " + zakaz.Id, model.FileName);
            File.Delete(model.FileName);
        }

        public async System.Threading.Tasks.Task SendPosetitelAccountDoc(OrderBindingModel model)
        {
            OrderViewModel zakaz = await GetOrder(model.Id);

            var ms = (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
            model.FileName += zakaz.Mail + "_Account_№" + zakaz.Id + "_" + ms + ".doc";

            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                    winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем текст
                range.Text = "Бронь № " + zakaz.Id + ". Въезд " + zakaz.ArrivalDate + "- Выезд " + zakaz.DepartureDate;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();

                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, zakaz.ServiceOrders.Count + zakaz.RoomOrders.Count + 2, 5, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                //шабка
                table.Cell(1, 1).Range.Text = "№";
                table.Cell(1, 2).Range.Text = "Наименование";
                table.Cell(1, 3).Range.Text = "Количество";
                table.Cell(1, 4).Range.Text = "Цена";
                table.Cell(1, 5).Range.Text = "Сумма";

                for (int i = 0; i < zakaz.ServiceOrders.Count; ++i)
                {
                    if (zakaz.ServiceOrders[i] != null)
                    {
                        table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
                        table.Cell(i + 2, 2).Range.Text = zakaz.ServiceOrders[i].ServiceName;
                        table.Cell(i + 2, 3).Range.Text = zakaz.ServiceOrders[i].Count.ToString();
                        table.Cell(i + 2, 4).Range.Text = zakaz.ServiceOrders[i].Price.ToString();
                        table.Cell(i + 2, 5).Range.Text = zakaz.ServiceOrders[i].Total.ToString();
                    }
                }
                for (int i = 0; i < zakaz.RoomOrders.Count; ++i)
                {
                    if (zakaz.RoomOrders[i] != null)
                    {
                        table.Cell(zakaz.ServiceOrders.Count + i + 2, 1).Range.Text = (i + 1).ToString();
                        table.Cell(zakaz.ServiceOrders.Count + i + 2, 2).Range.Text = zakaz.RoomOrders[i].FormName;
                        table.Cell(zakaz.ServiceOrders.Count + i + 2, 3).Range.Text = "1";
                        table.Cell(zakaz.ServiceOrders.Count + i + 2, 4).Range.Text = zakaz.RoomOrders[i].Price.ToString();
                        table.Cell(zakaz.ServiceOrders.Count + i + 2, 5).Range.Text = zakaz.RoomOrders[i].Price.ToString();
                    }
                }
                table.Cell(zakaz.ServiceOrders.Count + zakaz.RoomOrders.Count + 2, 4).Range.Text = "Итого:";
                table.Cell(zakaz.ServiceOrders.Count + zakaz.RoomOrders.Count + 2, 5).Range.Text = zakaz.Sum.ToString();
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(model.FileName, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
            await SendMail(zakaz.Mail, "Бронь", "Номер брони № " + zakaz.Id, model.FileName);
            File.Delete(model.FileName);
        }

        public async System.Threading.Tasks.Task SaveReservation(OrderBindingModel model)
        {
            //OrderViewModel list = await GetOrder(model.Id);

            var list = await GetOrder(model.Id);

            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(model.FontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //вставляем заголовок
            var phraseTitle = new Phrase("Бронь № " + list.Id + ". Въезд " + list.ArrivalDate + "- Выезд " + list.DepartureDate,
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(5)
            {
                TotalWidth = 800F
            };
            table.SetTotalWidth(new float[] { 160, 160, 140, 140, 140 });
            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("№", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Наименование", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Кол-во", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Цена", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Сумма", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.ServiceOrders.Count; i++)
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.ServiceOrders[i].ServiceName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.ServiceOrders[i].Count.ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.ServiceOrders[i].Price.ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.ServiceOrders[i].Total.ToString(), fontForCells))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                table.AddCell(cell);
            }
            for (int i = 0; i < list.RoomOrders.Count; i++)
            {
                cell = new PdfPCell(new Phrase((i + 1).ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.RoomOrders[i].FormName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("1", fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.RoomOrders[i].Price.ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list.RoomOrders[i].Price.ToString(), fontForCells))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                table.AddCell(cell);
            }
            //вставляем итого
            cell = new PdfPCell(new Phrase("Итого:", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 1,
                Border = 0
            };
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(list.Sum.ToString(), fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            table.AddCell(cell);

            //вставляем таблицу
            doc.Add(table);

            doc.Close();
        }
    }
}
