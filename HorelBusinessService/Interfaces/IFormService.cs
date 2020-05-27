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

        Task AddFreeServiceElement(FormFreeServiceBindingModel model);

        Task DelFreeServiceElement(FormFreeServiceBindingModel model);

        Task AddImageElement(ImageBindingModel model);

        Task DelImageElement(ImageBindingModel model);

        Task UpdElement(FormBindingModel model);

        Task DelElement(int id);
    }
}
