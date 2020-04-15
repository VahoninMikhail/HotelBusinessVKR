﻿namespace HotelBusinessModel
{
    public class RoomOrder
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int OrderId { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public virtual Room Room { get; set; }

        public virtual Order Order { get; set; }
    }
}
