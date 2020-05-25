using HorelBusinessService.BindingModels;
using HorelBusinessService.Interfaces;
using HorelBusinessService.ViewModels;
using HotelBusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HorelBusinessService.ImplementationsBD
{
    public class FormService : IFormService
    {
        private AbstractDbContext context;

        public FormService(AbstractDbContext context)
        {
            this.context = context;
        }

        public async Task AddElement(FormBindingModel model)
        {
            Form element1 = await context.Forms.FirstOrDefaultAsync(rec => rec.FormName == model.FormName);
            if (element1 != null)
            {
                throw new Exception("Already have a employee with such a name");
            }
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var element = new Form
                    {
                        FormName = model.FormName,
                        Specifications = model.Specifications,
                        Price = model.Price
                    };
                    context.Forms.Add(element);
                    await context.SaveChangesAsync();

                   /*var groupServices = model.FormFreeServices.GroupBy(rec => rec.ServiceId).Select(rec => new FormFreeServiceBindingModel
                    {
                        ServiceId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    if (groupServices != null)
                    {
                        foreach (var groupService in groupServices)
                        {
                            context.FormFreeServices.Add(new FormFreeService
                            {
                                FormId = element.Id,
                                Count = groupService.Count,
                                Price = context.Services.Where(rec => rec.Id == groupService.ServiceId).FirstOrDefault().Price,
                                ServiceId = groupService.ServiceId
                            });

                        }
                    }
                    await context.SaveChangesAsync();*/

                    if (model.Images.Count != 0)
                    {
                        foreach (var image in model.Images)
                        {
                            var buffer = image.Image;

                            HttpPostedFileBase objFile = new MemoryPostedFile(buffer);

                            try
                            {
                                if (objFile != null && objFile.ContentLength > 0)
                                {
                                    context.Images.Add(new Image
                                    {
                                        FileByteArr = buffer,
                                        FormId = element.Id
                                    });
                                    await context.SaveChangesAsync();
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
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

        public async Task DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Form element = await context.Forms.FirstOrDefaultAsync(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.FormFreeServices.RemoveRange(
                                            context.FormFreeServices.Where(rec => rec.FormId == id));
                        context.Forms.Remove(element);
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

        public async Task<FormViewModel> GetElement(int id)
        {
            Form element = await context.Forms.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                var serviceForms = await context.FormFreeServices.Where(rec => rec.FormId == element.Id).Include(rec => rec.Service).Select(rec => new FormFreeServiceViewModel
                {
                    Id = rec.Id,
                    ServiceName = rec.Service.ServiceName,
                    Count = rec.Count,
                    Price = rec.Price,
                    Total = rec.Count * rec.Price
                }).ToListAsync();
                var image = await context.Images.Where(rec => rec.FormId == element.Id).Select(rec => new ImageViewModel
                {
                    Image = rec.FileByteArr
                }).ToListAsync();
                var sum = serviceForms.Select(rec => rec.Total).DefaultIfEmpty(0).Sum();
                var paid = context.Payments.Where(rec => rec.OrderId == element.Id).Select(rec => rec.Summ).DefaultIfEmpty(0).Sum();
                return new FormViewModel
                {
                    Id = element.Id,
                    FormName = element.FormName,
                    Price = element.Price,
                    Specifications = element.Specifications,
                    FormFreeServices = serviceForms,
                    Images = image
                };
            }
            throw new Exception("Элемент не найден");
        }

        public async Task<List<FormViewModel>> GetList()
        {
            List<FormViewModel> result = await context.Forms.Select(rec => new FormViewModel
            {
                Id = rec.Id,
                FormName = rec.FormName,
                Specifications = rec.Specifications,
                Price = rec.Price,
                Rooms = rec.Rooms.Where(r => r.FormId == rec.Id).Select(r => new RoomViewModel
                {
                    RoomName = r.RoomName,
                    FormName = r.Form.FormName
                }).ToList(),
                Images = rec.Images.Where(r => r.FormId == rec.Id).Select(r => new ImageViewModel
                {
                    Image = r.FileByteArr
                }).ToList()
            })
                .ToListAsync();
            return result;
        }

        public async Task UpdElement(FormBindingModel model)
        {
            Form element = await context.Forms.FirstOrDefaultAsync(rec =>
                                    rec.FormName == model.FormName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть вид комнаты с таким названием");
            }
            element = await context.Forms.FirstOrDefaultAsync(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FormName = model.FormName;
            element.Specifications = model.Specifications;
            element.Price = model.Price;

            if (model.Images.Count != 0)
            {
                foreach (var image in model.Images)
                {
                    var buffer = image.Image;

                    HttpPostedFileBase objFile = new MemoryPostedFile(buffer);

                    try
                    {
                        if (objFile != null && objFile.ContentLength > 0)
                        {
                            context.Images.Add(new Image
                            {
                                FileByteArr = buffer,
                                FormId = element.Id
                            });
                            await context.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            await Task.Run(() => context.Database.BeginTransaction().Commit());
            context.SaveChanges();
        }
    }
}
