using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetList();

        Task<List<OrderViewModel>> GetList(string userId);

        Task<OrderViewModel> GetElement(int id);

        Task AddElement(OrderBindingModel model);

        Task UpdElement(OrderBindingModel model);

        Task DelElement(int id);

        Task CreatePayment(PaymentBindingModel model);
    }
}
