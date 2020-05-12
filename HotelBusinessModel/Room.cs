using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBusinessModel
{
    public class Room
    {
        public int Id { get; set; }
         
        public int FormId { get; set; }

        public virtual Form Form { get; set; }

        [Required]
        public int RoomName { get; set; }

        public bool Active { get; set; }

        [ForeignKey("RoomId")]
        public virtual List<RoomOrder> RoomOrders { get; set; }
    }
}