using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Order
{
    public class Orders
    {
        public OrderId Id { get; }
        public UserId UserId { get; }
        public List<OrderItem.OrderItem> Items { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeliveredAt { get; private set; }
        public string Status { get; private set; } // e.g., "Pending", "Delivered", "Canceled"

        public Orders(OrderId id, UserId userId, List<OrderItem.OrderItem> items)
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