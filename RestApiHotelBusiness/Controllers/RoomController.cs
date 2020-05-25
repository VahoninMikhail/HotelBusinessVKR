using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomService service;

        public RoomController(IRoomService service)
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
        public async Task AddElement(RoomBindingModel model)
        {
            await service.AddElement(model);
        }

        [HttpPost]
        public async Task UpdElement(RoomBindingModel model)
        {
            await service.UpdElement(model);
        }

        [HttpPost]
        public async Task DelElement(int id)
        {
            await service.DelElement(id);
        }
    }
}
