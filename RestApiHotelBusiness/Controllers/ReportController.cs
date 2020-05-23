using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService service;

        private readonly string TempPath;

        private readonly string ResourcesPath;

        public ReportController(IReportService service)
        {
            this.service = service;
            TempPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Temp/");
            ResourcesPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/");
        }

        [HttpPost]
        public async Task SendPosetitelAccountXls(ReportBindingModel model)
        {
            model.FileName = TempPath;
            await service.SendPosetitelAccountXls(model);
        }
    }
}