using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class UserBindingModel
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserPhone { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
