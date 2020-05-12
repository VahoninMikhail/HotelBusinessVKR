using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HotelBusinessModel;
using Microsoft.AspNet.Identity.Owin;
using RestApiHotelBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RestApiHotelBusiness.Controllers
{
    public class UserController : ApiController
    {
     /*   private readonly IUserService service;

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public UserController(IUserService service)
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
        public async Task<IHttpActionResult> Get(string id)
        {
            var element = await service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public async Task AddElement(RegisterBindingModel model)
        {
            var user = new User() { UserName = model.Email, Email = model.Email, UserFIO = model.UserFIO, Bonuses = 0, Active = true };

            await UserManager.CreateAsync(user, model.Password);
        }

        [HttpPut]
        public async Task UpdElement(UserBindingModel model)
        {
            await service.UpdElement(model);
        }

        [HttpDelete]
        public async Task DelElement(string id)
        {
            await service.DelElement(id);
        }

       /* [HttpPut]
        public async Task RaisePremium(RetributionBindingModel model)
        {
            await service.RaisePremium(model);
        }

        [HttpPut]
        public async Task DecreasePremium(RetributionBindingModel model)
        {
            await service.DecreasePremium(model);
        }*/
    }
}
