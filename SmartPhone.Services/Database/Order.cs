using System;
using System.Collections.Generic;

namespace SmartPhone.Services.Database
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
    }
} 