using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string LockoutEnabled { get; set; }

        [DataMember]
        public int Bonuses { get; set; }
    }
}
