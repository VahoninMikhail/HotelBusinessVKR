using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IRoomService
    {
        Task<List<RoomViewModel>> GetList();

        Task<RoomViewModel> GetElement(int id);

        Task AddElement(RoomBindingModel model);

        Task UpdElement(RoomBindingModel model);

        Task DelElement(int id);
    }
}