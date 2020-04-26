using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IServiceService
    {
        Task<List<ServiceViewModel>> GetList();

        Task<ServiceViewModel> GetElement(int id);

        Task AddElement(ServiceBindingModel model);

        Task UpdElement(ServiceBindingModel model);

        Task DelElement(int id);
    }
}
