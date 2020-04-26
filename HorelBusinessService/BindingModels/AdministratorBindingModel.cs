using System.Runtime.Serialization;

namespace HorelBusinessService.BindingModels
{
    [DataContract]
    public class AdministratorBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string AdministratorFIO { get; set; }

        [DataMember]
        public string AdministratorMail { get; set; }
    }
}
