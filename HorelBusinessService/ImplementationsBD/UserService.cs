using HorelBusinessService.App;
using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HorelBusinessService.ImplementationsBD
{
    public class UserService /*: IUserService*/
    {
        /*   private AbstractDbContext context;

           public UserService(AbstractDbContext context)
           {
               this.context = context;
           }

           public static UserService Create(AbstractDbContext context)
           {
               return new UserService(context);
           }

           public async Task AddElement(UserCreateBindingModel model)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.UserFIO == model.UserFIO);
               if (element != null)
               {
                   throw new Exception("Already have a client with such a name");
               }
               element = await context.Users.FirstOrDefaultAsync(rec => rec.UserName == model.UserName);
               if (element != null)
               {
                   throw new Exception("Already have a client with such a email");
               }
               context.Users.Add(new User
               {
                   UserFIO = model.UserFIO,
                   UserName = model.UserName,
                   UserPhone = model.UserPhone,
                   Bonuses = 0,
                   PasswordHash = model.PasswordHash,
                   SecurityStamp = model.SecurityStamp,
                   Active = true
               });
               await context.SaveChangesAsync();
           }

           public async Task DecreaseBonuses(RepaymentBindingModel model)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == model.UserId);
               if (element == null)
               {
                   throw new Exception("Элемент не найден");
               }
               element.Bonuses -= model.Fine;
               await context.SaveChangesAsync();
           }

           public async Task DelElement(string id)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == id);
               if (element != null)
               {
                   context.Users.Remove(element);
                   await context.SaveChangesAsync();
               }
               else
               {
                   throw new Exception("Элемент не найден");
               }
           }

           public async Task<UserViewModel> GetElement(string id)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == id);
               if (element != null)
               {
                   return new UserViewModel
                   {
                       Id = element.Id,
                       UserFIO = element.UserFIO,
                       UserPhone = element.UserPhone,
                       UserName = element.UserName,
                       Bonuses = element.Bonuses,
                       Active = (element.Active) ? "Active" : "Locked"
                   };
               }
               throw new Exception("Element not found");
           }

           public async Task<List<UserViewModel>> GetList()
           {
               List<UserViewModel> result = await context.Users.Select(rec => new UserViewModel
               {
                   Id = rec.Id,
                   UserFIO = rec.UserFIO,
                   UserName = rec.UserName,
                   UserPhone = rec.UserPhone,
                   Bonuses = rec.Bonuses,
                   Active = (rec.Active) ? "Active" : "Locked"
               })
                   .ToListAsync();
               return result;
           }

           public async Task BlockClients()
           {
               DateTime now = DateTime.Now;
               var users = await context.Orders.Where(rec => rec.DepartureDate < now && rec.OrderStatus != OrderStatus.Оплачен).Include(rec => rec.User)
                   .Select(rec => rec.User).Distinct().ToListAsync();
               await StartBlock(users);
               await context.SaveChangesAsync();
           }

           private Task StartBlock(List<User> users)
           {
               CountdownEvent countdown = new CountdownEvent(1);
               foreach (var user in users)
               {
                   countdown.AddCount();

                   Task.Run(() =>
                   {
                       user.Active = false;
                       countdown.Signal();
                   });
               }
               countdown.Signal();

               countdown.Wait();
               return Task.Run(() => true);
           }

           public async Task RaiseBonuses(RepaymentBindingModel model)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == model.UserId);
               if (element == null)
               {
                   throw new Exception("Элемент не найден");
               }
               element.Bonuses += model.Calculation;
               await context.SaveChangesAsync();
           }

           public async Task UpdElement(UserBindingModel model)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec =>
                                       (rec.UserFIO == model.UserFIO || rec.UserName == model.UserName) && rec.Id != model.Id);
               if (element != null)
               {
                   throw new Exception("Уже есть посетитель с такими данными");
               }
               element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == model.Id);
               if (element == null)
               {
                   throw new Exception("Элемент не найден");
               }
               element.UserFIO = model.UserFIO;
               element.UserPhone = model.UserPhone;
               element.UserName = model.UserName;
               await context.SaveChangesAsync();
           }

           public async Task<AppUser> GetUser(string id)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.Id == id);
               if (element != null)
               {
                   return new AppUser
                   {
                       Id = new AppId { Role = ApplicationRole.User, Id = element.Id },
                       UserName = element.UserName,
                       PasswordHash = element.PasswordHash,
                       SecurityStamp = element.SecurityStamp
                   };
               }
               return null;
           }

           public async Task<AppUser> GetUserByName(int name)
           {
               User element = await context.Users.FirstOrDefaultAsync(rec => rec.UserName.Equals(name));
               if (element != null)
               {
                   return new AppUser
                   {
                       Id = new AppId { Role = ApplicationRole.User, Id = element.Id },
                       UserName = element.UserName,
                       PasswordHash = element.PasswordHash,
                       SecurityStamp = element.SecurityStamp
                   };
               }
               return null;
           }
       }*/
    }
}