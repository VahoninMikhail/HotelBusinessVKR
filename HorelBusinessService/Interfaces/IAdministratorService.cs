using HorelBusinessService.App;
using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IAdministratorService
    {
        Task<List<AdministratorViewModel>> GetList();

        Task<AdministratorViewModel> GetElement(int id);

        Task AddElement(AdministratorCreateBindingModel model);

        Task UpdElement(AdministratorBindingModel model);

        Task DelElement(int id);

        Task<AppUser> GetUser(int id);

        Task<AppUser> GetUserByName(string name);

        Task BackUp();
    }
}
