using Domain.MenuItem;
using Domain.Order;

namespace Domain.OrderItem;

public class OrderItem
{
    public OrderItemId Id { get; }
    public MenuItemId MenuItemId { get; }
    public OrderId OrderId { get; } // Це поле для зв'язку з замовленням

    public int Quantity { get; private set; }
    public decimal Price { get; private set; } // Ціна на момент замовлення

    public OrderItem(OrderItemId id, MenuItemId menuItemId, int quantity, decimal price)
    {
        Id = id;
        MenuItemId = menuItemId;
        Quantity = quantity;
        Price = price;
    }

    public decimal TotalPrice => Quantity * Price;

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}