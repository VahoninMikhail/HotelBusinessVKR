using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class ImageBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public byte[] Image { get; set; }
    }
}
