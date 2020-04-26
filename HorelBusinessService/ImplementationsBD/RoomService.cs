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
    public class RoomService : IRoomService
    {
        private AbstractDbContext context;

        public RoomService(AbstractDbContext context)
        {
            this.context = context;
        }

        public async Task AddElement(RoomBindingModel model)
        {
            Room element = await context.Rooms.FirstOrDefaultAsync(rec => rec.RoomName == model.RoomName);
            if (element != null)
            {
                throw new Exception("Already have a employee with such a name");
            }
            context.Rooms.Add(new Room
            {
                RoomName = model.RoomName,
                FormId = model.FormId,
                Active = true
            });
            await context.SaveChangesAsync();
        }

        public async Task DelElement(int id)
        {
            Room element = await context.Rooms.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                context.Rooms.Remove(element);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public async Task<RoomViewModel> GetElement(int id)
        {
            Room element = await context.Rooms.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                return new RoomViewModel
                {
                    Id = element.Id,
                    RoomName = element.RoomName,
                    FormId = element.FormId,
                    FormName = context.Forms.Where(rec => rec.Id == element.FormId).Select(rec => rec.FormName).FirstOrDefault(),
                    Active = (element.Active) ? "Active" : "Locked"
                };
            }
            throw new Exception("Element not found");
        }

        public async Task<List<RoomViewModel>> GetList()
        {
            List<RoomViewModel> result = await context.Rooms.Select(rec => new RoomViewModel
            {
                Id = rec.Id,
                RoomName = rec.RoomName,
                FormName = context.Forms.Where(recc => recc.Id == rec.FormId).Select(recc => recc.FormName).FirstOrDefault(),
                Active = (rec.Active) ? "Active" : "Locked"
            })
                .ToListAsync();
            return result;
        }

        public async Task UpdElement(RoomBindingModel model)
        {
            Room element = await context.Rooms.FirstOrDefaultAsync(rec =>
                                    rec.RoomName == model.RoomName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Такой номер уже есть");
            }
            element = await context.Rooms.FirstOrDefaultAsync(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.RoomName = model.RoomName;
            element.FormId = model.FormId;
            element.Id = model.Id;
            await context.SaveChangesAsync();
        }
    }
}

