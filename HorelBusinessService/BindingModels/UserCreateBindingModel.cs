using HorelBusinessService.App;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class UserCreateBindingModel : AppUser
    {
        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserPhone { get; set; }
    }
}
