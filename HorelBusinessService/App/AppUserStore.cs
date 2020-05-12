using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace HorelBusinessService.App
{
    public class AppUserStore /*: UserStore<AppUser, AppRole, AppId, AppUserLogin, AppUserRole, AppUserClaim>*/
    {
        /*private readonly IAdministratorService serviceA;

        private readonly IUserService serviceC;

        public AppUserStore(AbstractDbContext context, IAdministratorService serviceA, IUserService serviceC) : base(context)
        {
            this.serviceA = serviceA;
            this.serviceC = serviceC;
        }

        public override Task<AppUser> FindByIdAsync(AppId userId)
        {
            if (userId.Role.Equals(ApplicationRole.Administrator))
            {
                return serviceA.GetUser(userId.Id);
            }
            else if (userId.Role.Equals(ApplicationRole.User))
            {
                return serviceC.GetUser(userId.Id);
            }
            return null;
        }
        public override Task CreateAsync(AppUser user)
        {

            if (user is AdministratorBindingModel)
            {
                return serviceA.AddElement(user as AdministratorBindingModel);
            }
            else if (user is UserCreateBindingModel)
            {
                return serviceC.AddElement(user as UserCreateBindingModel);
            }
            return null;
        }

        public override Task DeleteAsync(AppUser user)
        {
            if (user.Id.Role.Equals(ApplicationRole.Administrator))
            {
                return serviceA.DelElement(user.Id.Id);
            }
            else if (user.Id.Role.Equals(ApplicationRole.User))
            {
                return serviceC.DelElement(user.Id.Id);
            }

            return null;
        }

        public async override Task<AppUser> FindByNameAsync(string userName)
        {
            AppUser user = null;

            if ((user = await serviceC.GetUserByName(userName)) != null)
            {
                return user;
            }
            if ((user = await serviceA.GetUserByName(userName)) != null)
            {
                return user;
            }
            return null;
        }

        public override Task UpdateAsync(AppUser user)
        {
            if (user is AdministratorBindingModel)
            {
                return serviceA.UpdElement(user as AdministratorBindingModel);
            }
            return null;
        }*/
    }
}
