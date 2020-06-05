using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IReportService
    {

        Task SendMail(ReviewBindingModel model);

        Task<List<PaymentViewModel>> GetPays(ReportBindingModel model);

        Task<List<ReportRoomsViewModel>> GetReportRooms(ReportBindingModel model);       
    }
}
