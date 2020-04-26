using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class UserBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserPhone { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
