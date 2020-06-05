using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService service;

        public ReportController(IReportService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IHttpActionResult> GetPays(ReportBindingModel model)
        {
            var list = await service.GetPays(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetReportRooms(ReportBindingModel model)
        {
            var list = await service.GetReportRooms(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task SendReplyReview(ReviewBindingModel model)
        {
            await service.SendMail(model);
        }
    }
}