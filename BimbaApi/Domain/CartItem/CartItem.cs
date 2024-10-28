using Domain.MenuItem;

namespace Domain.CartItem;

public class CartItem
{
    public CartItemId Id { get; }
    public MenuItemId MenuItemId { get; }
    public int Quantity { get; private set; }

    public CartItem(MenuItemId menuItemId, int quantity)
    {
        Id = CartItemId.New();
        MenuItemId = menuItemId;
        Quantity = quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}