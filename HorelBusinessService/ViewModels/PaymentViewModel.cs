using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class PaymentViewModel
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string UserMail { get; set; }

        [DataMember]
        public string DateImplement { get; set; }

        [DataMember]
        public decimal Summ { get; set; }

        [DataMember]
        public string PayType { get; set; }
    }
}
