using HotelBusinessModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HorelBusinessService
{
    public class AbstractDbContext : IdentityDbContext<User>
    {
        public AbstractDbContext() : base("HotelBusiness")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public static AbstractDbContext Create()
        {
            return new AbstractDbContext();
        }

        public override Task<int> SaveChangesAsync()
        {
            try
            {
                return base.SaveChangesAsync();
            }
            catch (Exception)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw;
            }
        }
        public virtual DbSet<Administrator> Administrators { get; set; }

        public virtual DbSet<Form> Forms { get; set; }

        public virtual DbSet<FormFreeService> FormFreeServices { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<RoomOrder> RoomOrders { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<Image> Images { get; set; }
    }
}
