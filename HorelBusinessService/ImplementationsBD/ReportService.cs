using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HorelBusinessService.ImplementationsBD
{
    public class ReportService : IReportService
    {
        private AbstractDbContext context;

        public ReportService(AbstractDbContext context)
        {
            this.context = context;
        }

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

        public async Task SendPosetitelAccountXls(ReportBindingModel model)
        {
            OrderViewModel zakaz = await GetOrder(model.OrderId);

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
                excelcells.Value2 = "Бронь № " + zakaz.Id + "Въезд " + zakaz.ArrivalDate + "Выезд " + zakaz.DepartureDate;
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
                                            excelcells.get_Offset(zakaz.ServiceOrders.Count()+zakaz.RoomOrders.Count(), 4));
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

        
    }
}
