using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBusinessModel
{
    public class Form
    {
        public int Id { get; set; }

        [Required]
        public string FormName { get; set; }

        [Required]
        public string Specifications { get; set; }

        [ForeignKey("FormId")]
        public virtual List<Room> Rooms { get; set; }

        [ForeignKey("FormId")]
        public virtual List<FormFreeService> FormFreeServices { get; set; }
    }
}
