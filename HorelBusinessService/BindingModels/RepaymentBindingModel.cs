using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class RepaymentBindingModel
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public int Calculation { get; set; }

        [DataMember]
        public int Fine { get; set; }
    }
}
