using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBusinessModel
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<Payment> Payments { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<ServiceOrder> ServiceOrders { get; set; }

        [ForeignKey("OrderId")]
        public virtual List<RoomOrder> RoomOrders { get; set; }
    }
}