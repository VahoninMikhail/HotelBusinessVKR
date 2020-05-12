using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class FormBindingModel
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
        public List<FormFreeServiceBindingModel> FormFreeServices { get; set; }
    }
}
