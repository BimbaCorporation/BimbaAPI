using Domain.User;
using System;
using System.Collections.Generic;

namespace Domain.Order
{
    public class Order
    {
        public OrderId Id { get; }
        public UserId UserId { get; }
        public List<OrderItem.OrderItem> Items { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeliveredAt { get; private set; }
        public string Status { get; private set; } // e.g., "Pending", "Delivered", "Canceled"

        public Order(OrderId id, UserId userId, List<OrderItem.OrderItem> items)
        {
            Id = id;
            UserId = userId;
            Items = items;
            CreatedAt = DateTime.UtcNow;
            Status = "Pending";
        }

        public void MarkAsDelivered()
        {
            DeliveredAt = DateTime.UtcNow;
            Status = "Delivered";
        }

        public void CancelOrder()
        {
            Status = "Canceled";
        }
    }
}