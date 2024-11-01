using Domain.Order;
using Domain.User; // Додайте це

namespace Domain.OrderHistory
{
    public class OrderHistory
    {
        public OrderHistoryId Id { get; }
        public UserId UserId { get; } 
        public List<OrderId> Orders { get; private set; }

        public OrderHistory(OrderHistoryId id, UserId userId)
        {
            Id = id;
            UserId = userId;
            Orders = new List<OrderId>();
        }

        public void AddOrder(OrderId orderId)
        {
            Orders.Add(orderId);
        }
    }
}