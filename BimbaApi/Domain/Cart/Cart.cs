using Domain.CartItem;
using Domain.MenuItem;
using Domain.User;

namespace Domain.Cart;

public class Cart
{
    public CartId CartId { get; }
    public List<CartItems> Items { get; set; }

    public Cart(CartId cartId)
    {
        CartId = cartId;
        Items = new List<CartItems>();
    }

    public void AddItem(MenuItems items, int quantity)
    {
        var cartItem = Items.FirstOrDefault(i => i.MenuItemId == items.Id);
        if (cartItem == null)
        {
            Items.Add(new CartItems(items.Id, quantity)); // Не потрібно CartId тут
        }
        else
        {
            cartItem.UpdateQuantity(cartItem.Quantity + quantity);
        }
    }

    public void RemoveItem(MenuItemId itemId)
    {
        var cartItem = Items.FirstOrDefault(i => i.MenuItemId == itemId);
        if (cartItem != null)
        {
            Items.Remove(cartItem);
        }
    }
}