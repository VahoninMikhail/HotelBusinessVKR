using System.Runtime.Serialization;

namespace HotelBusinessWeb
{
    [DataContract]
    public class HttpErrorMessage
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ExceptionMessage { get; set; }

        [DataMember]
        public string MessageDetail { get; set; }

        [DataMember]
        public string Error_description { get; set; }
    }
}