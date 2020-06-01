using System;

namespace HotelBusinessModel
{
    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateImplement { get; set; }

        public decimal Summ { get; set; }

        public string PayType { get; set; }

        public virtual Order Order { get; set; }
    }
}