using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class UserPogashenieViewModel
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserFIO { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public List<OrderPogashenieViewModel> OrderPogashenies { get; set; }
    }
}