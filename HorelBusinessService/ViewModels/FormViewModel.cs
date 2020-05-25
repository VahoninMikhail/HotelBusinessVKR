using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class FormViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FormName { get; set; }

        [DataMember]
        public string Specifications { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<FormFreeServiceViewModel> FormFreeServices { get; set; }

        [DataMember]
        public List<RoomViewModel> Rooms { get; set; }

        [DataMember]
        public virtual List<ImageViewModel> Images { get; set; }
    }
}
