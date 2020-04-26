using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IFormService
    {
        Task<List<FormViewModel>> GetList();

        Task<FormViewModel> GetElement(int id);

        Task AddElement(FormBindingModel model);

        Task UpdElement(FormBindingModel model);

        Task DelElement(int id);
    }
}
