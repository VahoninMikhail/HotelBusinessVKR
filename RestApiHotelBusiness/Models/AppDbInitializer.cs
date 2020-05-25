using HorelBusinessService;
using HotelBusinessModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace RestApiHotelBusiness.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<AbstractDbContext>
    {
        protected override void Seed(AbstractDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "User" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new User
            {
                UserFIO = "Default",
                UserName = "Admin",
                PasswordHash = "Admin777"
            };
            var result = userManager.Create(admin, admin.PasswordHash);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
            }

            // создаем пользователей
            var user = new User
            {
                UserFIO = "Вахонин",
                UserName = "User",
                PasswordHash = "User777"
            };
            result = userManager.Create(user, user.PasswordHash);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role2.Name);
            }

            base.Seed(context);
        }
    }
}