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

        public async System.Threading.Tasks.Task SendMail(ReviewBindingModel model)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            SmtpClient stmpClient = null;
            try
            {
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                mailMessage.To.Add(new MailAddress(model.UserMail));
                mailMessage.Subject = "Ответ на отзыв по заказу: " + model.OrderId;
                mailMessage.Body = model.Text;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;

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
    
        public async Task<List<PaymentViewModel>> GetPays(ReportBindingModel model)
        {
            return await context.Payments.Where(rec => rec.DateImplement >= model.DateFrom && rec.DateImplement <= model.DateTo).Include(rec => rec.Order.User)
                .Select(rec => new PaymentViewModel
                {
                    UserFIO = rec.Order.User.UserFIO,
                    UserMail = rec.Order.User.UserName,
                    OrderId = rec.OrderId,
                    DateImplement = SqlFunctions.DateName("dd", rec.DateImplement) + " " +
                                            SqlFunctions.DateName("mm", rec.DateImplement) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DateImplement),
                    PayType = rec.PayType,
                    Summ = rec.Summ
                }).ToListAsync();
        }

        public async Task<List<ReportRoomsViewModel>> GetReportRooms(ReportBindingModel model)
        {
            return await context.Forms
                .Select(rec => new ReportRoomsViewModel
                {
                    FormName = rec.FormName,
                    CountFree = rec.Rooms.Count - context.RoomOrders.Where(rec1 => ((rec1.ArrivalDate <= model.DateFrom && rec1.DepartureDate > model.DateFrom) || (rec1.ArrivalDate >= model.DateFrom && rec1.ArrivalDate <= model.DateTo)) && rec1.Room.FormId==rec.Id).Count(),
                    CountOccupied = rec.Rooms.Count - (rec.Rooms.Count - context.RoomOrders.Where(rec1 => ((rec1.ArrivalDate <= model.DateFrom && rec1.DepartureDate > model.DateFrom) || (rec1.ArrivalDate >= model.DateFrom && rec1.ArrivalDate <= model.DateTo)) && rec1.Room.FormId == rec.Id).Count()),
                    Price = rec.Price
                }).ToListAsync();
        }
    }
}
