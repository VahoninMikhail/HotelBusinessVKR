using System.ComponentModel.DataAnnotations;

namespace HotelBusinessModel
{
    public class Administrator
    {
        public int Id { get; set; }

        [Required]
        public string AdministratorFIO { get; set; }

        [Required]
        public string AdministratorMail { get; set; }

        [Required]
        public string AdministratorPhone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Zaschita { get; set; }
    }
}
