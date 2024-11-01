using Domain.MenuItem;
using Domain.Order;

namespace Domain.OrderItem
{
    public class OrderItem
    {
        public OrderItemId Id { get; private set; }
        public MenuItemId MenuItemId { get; private set; } // This will be mapped by EF Core
        public OrderId OrderId { get; private set; }
        
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        
        public decimal TotalPrice => Quantity * Price;

        // Public constructor for business logic
        public OrderItem(OrderItemId id, MenuItemId menuItemId, int quantity, decimal price)
        {
            Id = id;
            MenuItemId = menuItemId;
            Quantity = quantity;
            Price = price;
        }

        // Private parameterless constructor for EF Core
        private OrderItem() { }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}