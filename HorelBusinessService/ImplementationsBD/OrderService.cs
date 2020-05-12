using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace HorelBusinessService.ImplementationsBD
{
    public class OrderService : IOrderService
    {
        private readonly AbstractDbContext context;

        public OrderService(AbstractDbContext context)
        {
            this.context = context;
        }

        public async Task AddElement(OrderBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var element = new Order
                    {
                        UserId = model.UserId,
                        ArrivalDate = model.ArrivalDate,
                        DepartureDate = model.DepartureDate,
                        OrderStatus = OrderStatus.Начат,
                    };
                    context.Orders.Add(element);
                    await context.SaveChangesAsync();

                    var groupServices = model.ServiceOrders.GroupBy(rec => rec.ServiceId).Select(rec => new ServiceOrderBindingModel
                    {
                        ServiceId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    foreach (var groupService in groupServices)
                    {
                        context.ServiceOrders.Add(new ServiceOrder
                        {
                            OrderId = element.Id,
                            Count = groupService.Count,
                            Price = context.Services.Where(rec => rec.Id == groupService.ServiceId).FirstOrDefault().Price,
                            ServiceId = groupService.ServiceId,
                        });
                    }
                    await context.SaveChangesAsync();

                    var groupRooms = model.RoomOrders.GroupBy(rec => rec.RoomId).Select(rec => new RoomOrderBindingModel
                    {
                        RoomId = rec.Key
                    });
                    foreach (var groupRoom in groupRooms)
                    {
                        context.RoomOrders.Add(new RoomOrder
                        {
                            OrderId = element.Id,
                            ArrivalDate = groupRoom.ArrivalDate,
                            DepartureDate = groupRoom.DepartureDate,
                            Price = context.Forms.Where(rec => rec.Id == context.Rooms.Where(rec1 => rec1.Id == groupRoom.RoomId).FirstOrDefault().FormId).FirstOrDefault().Price,
                            RoomId = groupRoom.RoomId
                        });
                    }

                    await context.SaveChangesAsync();
                    if (model.Payed > 0)
                    {
                        await CreatePayment(new PaymentBindingModel
                        {
                            OrderId = element.Id,
                            Summ = model.Payed
                        });
                    }

                    await Task.Run(() => transaction.Commit());
                }
                catch (Exception ex)
                {
                    await Task.Run(() => transaction.Rollback());
                    throw;
                }
            }
        }

        public async Task CreatePayment(PaymentBindingModel model)
        {
            var serviceOrders = await context.ServiceOrders.Where(rec => rec.OrderId == model.OrderId).Include(rec => rec.Service).Select(rec => new ServiceOrderViewModel
            {
                Id = rec.Id,
                ServiceName = rec.Service.ServiceName,
                Count = rec.Count,
                Price = rec.Price,
                Total = rec.Count * rec.Price
            }).ToListAsync();
            var roomOrders = await context.RoomOrders.Where(rec => rec.OrderId == model.OrderId).Include(rec => rec.Room).Select(rec => new RoomOrderViewModel
            {
                Id = rec.Id,
                RoomName = rec.Room.RoomName,
                Price = rec.Price,
            }).ToListAsync();
            var remaind = serviceOrders.Select(rec => rec.Total).DefaultIfEmpty(0).Sum() - context.Payments.Where(rec => rec.OrderId == model.OrderId).Select(rec => rec.Summ).DefaultIfEmpty(0).Sum();
            if (remaind < model.Summ)
            {
                var user = await context.Orders.Where(rec => rec.Id == model.OrderId).Select(rec => rec.User).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Bonuses += (int)model.Summ - (int)remaind;
                }
                model.Summ = remaind;
            }
            var order = await context.Orders.FirstOrDefaultAsync(rec => rec.Id == model.OrderId);
            if (order != null)
            {
                order.OrderStatus = (remaind == model.Summ) ? OrderStatus.Оплачен : OrderStatus.Начат;
            }
            context.Payments.Add(new Payment
            {
                OrderId = model.OrderId,
                Summ = model.Summ,
                DateCreate = DateTime.Now
            });
            await context.SaveChangesAsync();
        }

        public async Task DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = await context.Orders.FirstOrDefaultAsync(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.ServiceOrders.RemoveRange(
                                            context.ServiceOrders.Where(rec => rec.OrderId == id));
                        context.Orders.Remove(element);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    await Task.Run(() => transaction.Commit());
                }
                catch (Exception)
                {
                    await Task.Run(() => transaction.Rollback());
                    throw;
                }
            }
        }

        public async Task<OrderViewModel> GetElement(int id)
        {
            Order element = await context.Orders.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                var serviceOrders = await context.ServiceOrders.Where(rec => rec.OrderId == element.Id).Include(rec => rec.Service).Select(rec => new ServiceOrderViewModel
                {
                    Id = rec.Id,
                    ServiceName = rec.Service.ServiceName,
                    Count = rec.Count,
                    Price = rec.Price,
                    Total = rec.Count * rec.Price
                }).ToListAsync();
                var sum = serviceOrders.Select(rec => rec.Total).DefaultIfEmpty(0).Sum();
                var paid = context.Payments.Where(rec => rec.OrderId == element.Id).Select(rec => rec.Summ).DefaultIfEmpty(0).Sum();
                return new OrderViewModel
                {
                    Id = element.Id,
                    UserFIO = context.Users.Where(rec => rec.Id == element.UserId).Select(rec => rec.UserFIO).FirstOrDefault(),
                    UserId = element.UserId,
                    ArrivalDate = element.ArrivalDate.ToLongDateString(),
                    DepartureDate = element.DepartureDate.ToLongDateString(),
                    ServiceOrders = serviceOrders,
                    OrderStatus = element.OrderStatus.ToString(),
                    Sum = sum,
                    Paid = paid,
                    Pogashenie = sum - paid,
                    PogashenieDate = element.DepartureDate
                };
            }
            throw new Exception("Элемент не найден");
        }

        public async Task<List<OrderViewModel>> GetList()
        {
            return await context.Orders.Include(rec => rec.User)//.Include(rec=>rec.ServiceOrders).Include(rec=>rec.Pays)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    UserFIO = rec.User.UserFIO,
                    Mail = rec.User.UserName,
                    UserId = rec.UserId,
                    ArrivalDate = SqlFunctions.DateName("dd", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("mm", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.ArrivalDate),
                    DepartureDate = SqlFunctions.DateName("dd", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("mm", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DepartureDate),
                    OrderStatus = rec.OrderStatus.ToString(),
                    PogashenieDate = rec.DepartureDate,
                    //Sum = rec.ServiceOrders.Select(r=>r.Price * r.Count).DefaultIfEmpty(0).Sum(),
                    //Paid = rec.Pays.Select(r=>r.Summ).DefaultIfEmpty(0).Sum(),
                    //Credit = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() - rec.Pays.Select(r => r.Summ).DefaultIfEmpty(0).Sum()
                }).ToListAsync();
        }

        public async Task<List<OrderViewModel>> GetList(string clientId)
        {
            return await context.Orders.Where(rec => rec.UserId == clientId).Include(rec => rec.User).Include(rec => rec.ServiceOrders)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    UserFIO = rec.User.UserFIO,
                    Mail = rec.User.UserName,
                    UserId = rec.UserId,
                    ArrivalDate = SqlFunctions.DateName("dd", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("mm", rec.ArrivalDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.ArrivalDate),
                    DepartureDate = SqlFunctions.DateName("dd", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("mm", rec.DepartureDate) + " " +
                                            SqlFunctions.DateName("yyyy", rec.DepartureDate),
                    OrderStatus = rec.OrderStatus.ToString(),
                    PogashenieDate = rec.DepartureDate,
                    Sum = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum(),
                    Paid = rec.Payments.Select(r => r.Summ).DefaultIfEmpty(0).Sum(),
                    Pogashenie = rec.ServiceOrders.Select(r => r.Price * r.Count).DefaultIfEmpty(0).Sum() - rec.Payments.Select(r => r.Summ).DefaultIfEmpty(0).Sum()
                }).ToListAsync();
        }

        public Task UpdElement(OrderBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
