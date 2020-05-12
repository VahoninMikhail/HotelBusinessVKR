using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public void AddElement(RoomBindingModel model)
        {
            service.AddElement(model);
        }

        [HttpPut]
        public void UpdElement(RoomBindingModel model)
        {
            service.UpdElement(model);
        }

        [HttpDelete]
        public void DelElement(int id)
        {
            service.DelElement(id);
        }
    }
}
