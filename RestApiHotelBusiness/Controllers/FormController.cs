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
    public class FormController : ApiController
    {
        private readonly IFormService service;

        public FormController(IFormService service)
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

       /* [HttpGet]
        [Route("api/Zakaz/GetPosetitelList/{posetitelId}")]
        public async Task<IHttpActionResult> GetPosetitelList(int posetitelId)
        {
            var list = await service.GetList(posetitelId);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }*/

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
        public async Task AddElement(FormBindingModel model)
        {
            await service.AddElement(model);
        }

        [HttpDelete]
        public async Task DelElement(int id)
        {
            await service.DelElement(id);
        }

        [HttpPut]
        public void UpdElement(FormBindingModel model)
        {
            service.UpdElement(model);
        }
    }
}
