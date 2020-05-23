using HorelBusinessService.BindingModels;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IReportService
    {
        // Task<List<PosetitelPogashenieViewModel>> GetPosetitelPogashenies(ReportBindingModel model);

        // Task SendPosetitelPogashenieDoc(PosetitelPogashenieViewModel model, string TempPath);

        Task SendPosetitelAccountXls(ReportBindingModel model);

       // Task SendPosetitelAccountDoc(OrderBindingModel model);

     //   Task SendPosetitelReservationXls(ReportBindingModel model);

        //  Task SendPosetitelsPogashenies(ReportBindingModel model);

        //  Task<List<OplataViewModel>> GetPays(ReportBindingModel model);

        Task SendMail(string mailto, string caption, string message, string path = null);

        // Task SavePays(ReportBindingModel model);

    }
}
