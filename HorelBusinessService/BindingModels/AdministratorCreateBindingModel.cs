using HorelBusinessService.App;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class AdministratorCreateBindingModel : AppUser
    {
        [DataMember]
        public string AdministratorFIO { get; set; }
    }
}
