using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService service;

        private readonly string TempPath;

        private readonly string ResourcesPath;

        public OrderController(IOrderService service)
        {
            this.service = service;
            TempPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Temp/");
            ResourcesPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Resources/");
        }

        //получаем путь файлов проекта
        [HttpGet]
        public IHttpActionResult GetTemp()
        {
            return Ok(TempPath);
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
        public async Task<IHttpActionResult> GetListRoomOrder()
        {
            var list = await service.GetListRoomOrder();
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

        [HttpGet]
        public async Task<IHttpActionResult> GetListReview()
        {
            var list = await service.GetListReview();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task AddElement(OrderBindingModel model)
        {
            model.FileName = TempPath;
            model.FontPath = ResourcesPath + "TIMCYR.TTF";
            if (!File.Exists(model.FontPath))
            {
                File.WriteAllBytes(model.FontPath, Properties.Resources.TIMCYR);
            }
            await service.AddElement(model);
        }

        [HttpPost]
        public async Task AddReview(ReviewBindingModel model)
        {
            await service.AddReview(model);
        }

        [HttpPost]
        public async Task CreatePayment(PaymentBindingModel model)
        {
            await service.CreatePayment(model);
        }

        [HttpPost]
        [Route("api/Order/CloseOrder/{orderId}")]
        public async Task CloseOrder(int orderId)
        {
            await service.CloseOrder(orderId);
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

        //////////////
       
        [HttpPost]
        public async Task SaveReservation(OrderBindingModel model)
        {
            model.FileName = TempPath;
            model.FileName += "Бронь" + model.Id + ".pdf";
            model.FontPath = ResourcesPath + "TIMCYR.TTF";
            if (!File.Exists(model.FontPath))
            {
                File.WriteAllBytes(model.FontPath, Properties.Resources.TIMCYR);
            }
            await service.SaveReservation(model);
        }
    }
}
