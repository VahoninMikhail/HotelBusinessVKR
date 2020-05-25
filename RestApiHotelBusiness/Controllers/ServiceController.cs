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
    public class ServiceController : ApiController
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService service)
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
        public async Task AddElement(ServiceBindingModel model)
        {
            await service.AddElement(model);
        }

        [HttpPost]
        public async Task UpdElement(ServiceBindingModel model)
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