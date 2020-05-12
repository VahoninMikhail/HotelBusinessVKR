using HorelBusinessService.App;
using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetList();

        Task<UserViewModel> GetElement(string id);

        Task AddElement(UserCreateBindingModel model);

        Task UpdElement(UserBindingModel model);

        Task DelElement(string id);

        Task<AppUser> GetUser(string id);

        Task<AppUser> GetUserByName(string name);

        Task RaiseBonuses(RepaymentBindingModel model);

        Task DecreaseBonuses(RepaymentBindingModel model);

        Task BlockClients();
    }
}
