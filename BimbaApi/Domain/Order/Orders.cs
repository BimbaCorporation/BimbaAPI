using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Order
{
    public class Orders
    {
        public OrderId Id { get; private set; }
        public UserId UserId { get; private set; }
        public User.User? User { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeliveredAt { get; private set; }
        public string Status { get; private set; } // e.g., "Pending", "Delivered", "Canceled"

        // Make Items navigational and virtual, with private setter
        public virtual List<OrderItem.OrderItem> Items { get; private set; }

        // Public constructor for business logic
        public Orders(OrderId id, UserId userId, List<OrderItem.OrderItem> items)
        {
            Id = id;
            UserId = userId;
            Items = items ?? new List<OrderItem.OrderItem>();
            CreatedAt = DateTime.UtcNow;
            Status = "Pending";
        }

        // Private parameterless constructor for EF Core
        private Orders()
        {
            Items = new List<OrderItem.OrderItem>();
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