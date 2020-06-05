using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class ReviewBindingModel
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string UserMail { get; set; }

        [DataMember]
        public string Subject { get; set; }
    }
}
