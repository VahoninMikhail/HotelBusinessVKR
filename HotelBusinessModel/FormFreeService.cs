namespace HotelBusinessModel
{
    public class FormFreeService
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int FormId { get; set; }

        public virtual Service Service { get; set; }

        public virtual Form Form { get; set; }
    }
}
