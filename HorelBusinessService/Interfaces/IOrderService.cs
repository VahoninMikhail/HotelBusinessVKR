using HorelBusinessService.BindingModels;
using HorelBusinessService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorelBusinessService.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetList();

        Task<List<RoomOrderViewModel>> GetListRoomOrder();

        Task<List<OrderViewModel>> GetList(string userId);

        Task<OrderViewModel> GetElement(int id);

        Task AddElement(OrderBindingModel model);

        Task CloseOrder(int orderId);

        Task UpdElement(OrderBindingModel model);

        Task DelElement(int id);

        Task CreatePayment(PaymentBindingModel model);

        Task SendPosetitelAccountDoc(OrderBindingModel model);

        Task SaveReservation(OrderBindingModel model);

        Task SendPosetitelAccountXls(OrderBindingModel model);

        Task SendMail(string mailto, string caption, string message, string path = null);

        Task AddReview(ReviewBindingModel model);

        Task<List<ReviewViewModel>> GetListReview();
    }
}
