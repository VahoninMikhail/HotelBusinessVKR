using System.ComponentModel.DataAnnotations;

namespace HotelBusinessModel
{
    public class Review
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
