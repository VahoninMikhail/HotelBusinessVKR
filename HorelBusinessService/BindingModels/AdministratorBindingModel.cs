using HorelBusinessService.App;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class AdministratorBindingModel : AppUser
    {
        [DataMember]
        public string AdministratorFIO { get; set; }
    }
}
