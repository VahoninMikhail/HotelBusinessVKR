using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class ReviewViewModel
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserMail { get; set; }

        [DataMember]
        public string Text { get; set; }
    }
}