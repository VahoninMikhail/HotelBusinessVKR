using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class ReportRoomsViewModel
    {
        [DataMember]
        public string FormName { get; set; }

        [DataMember]
        public int CountFree { get; set; }

        [DataMember]
        public int CountOccupied { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}