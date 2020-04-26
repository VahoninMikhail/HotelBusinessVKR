using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HorelBusinessService.ImplementationsBD
{
    public class ServiceService : IServiceService
    {
        private AbstractDbContext context;

        public ServiceService(AbstractDbContext context)
        {
            this.context = context;
        }

        public async Task AddElement(ServiceBindingModel model)
        {
            Service element = await context.Services.FirstOrDefaultAsync(rec => rec.ServiceName == model.ServiceName);
            if (element != null)
            {
                throw new Exception("Already have a employee with such a name");
            }
            context.Services.Add(new Service
            {
                ServiceName = model.ServiceName,
                ServiceSpecification = model.ServiceSpecification,
                Price = model.Price
            });
            await context.SaveChangesAsync();
        }

        public async Task DelElement(int id)
        {
            Service element = await context.Services.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                context.Services.Remove(element);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public async Task<ServiceViewModel> GetElement(int id)
        {
            Service element = await context.Services.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                return new ServiceViewModel
                {
                    Id = element.Id,
                    ServiceName = element.ServiceName,
                    ServiceSpecification = element.ServiceSpecification,
                    Price = element.Price
                };
            }
            throw new Exception("Element not found");
        }

        public async Task<List<ServiceViewModel>> GetList()
        {
            List<ServiceViewModel> result = await context.Services.Select(rec => new ServiceViewModel
            {
                Id = rec.Id,
                ServiceName = rec.ServiceName,
                ServiceSpecification = rec.ServiceSpecification,
                Price = rec.Price
            })
                .ToListAsync();
            return result;
        }

        public async Task UpdElement(ServiceBindingModel model)
        {
            Service element = await context.Services.FirstOrDefaultAsync(rec =>
                                    rec.ServiceName == model.ServiceName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть услуга с таким названием");
            }
            element = await context.Services.FirstOrDefaultAsync(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ServiceName = model.ServiceName;
            element.ServiceSpecification = model.ServiceSpecification;
            element.Id = model.Id;
            await context.SaveChangesAsync();
        }
    }
}