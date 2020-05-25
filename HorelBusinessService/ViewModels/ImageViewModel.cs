using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class ImageViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public byte[] Image { get; set; }
    }
}
