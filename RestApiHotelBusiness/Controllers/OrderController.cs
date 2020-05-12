using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetList()
        {
            var list = await service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("api/Order/GetPosetitelList/{posetitelId}")]
        public async Task<IHttpActionResult> GetPosetitelList(string posetitelId)
        {
            var list = await service.GetList(posetitelId);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var element = await service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public async Task AddElement(OrderBindingModel model)
        {
            await service.AddElement(model);
        }

        [HttpDelete]
        public async Task DelElement(int id)
        {
            await service.DelElement(id);
        }

        public async Task AddPay(PaymentBindingModel model)
        {
            await service.CreatePayment(model);
        }
    }
}
