using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class OrderBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public DateTime PogashenieEnd { get; set; }

        [DataMember]
        public int Payed { get; set; }

        [DataMember]
        public List<ServiceOrderBindingModel> ServiceOrders { get; set; }
    }
}
