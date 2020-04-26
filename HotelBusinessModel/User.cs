using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBusinessModel
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserFIO { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPhone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Zaschita { get; set; }

        public int Bonuses { get; set; }

        public bool Active { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Order> Orders { get; set; }
    }
}