using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string UserPhone { get; set; }

        [DataMember]
        public int Bonuses { get; set; }

        [DataMember]
        public string Active { get; set; }
    }
}
