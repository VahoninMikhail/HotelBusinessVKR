using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class PaymentBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public decimal Summ { get; set; }

        [DataMember]
        public string PayType { get; set; }
    }
}
