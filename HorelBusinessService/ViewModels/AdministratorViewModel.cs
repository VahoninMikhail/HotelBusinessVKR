using System.Runtime.Serialization;

namespace HorelBusinessService.ViewModels
{
    [DataContract]
    public class AdministratorViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string AdministratorFIO { get; set; }

        [DataMember]
        public string AdministratorMail { get; set; }

        [DataMember]
        public string AdministratorPhone { get; set; }
    }
}
