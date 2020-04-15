namespace HotelBusinessModel
{
    public class ServiceOrder
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int OrderId { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public virtual Service Service { get; set; }

        public virtual Order Order { get; set; }
    }
}
