using Domain.CartItem;
using Domain.MenuItem;
using Domain.User;

namespace Domain.Cart;

public class Cart
{
    public UserId UserId { get; }
    public List<CartItems> Items { get; set; }

    public Cart(UserId userId)
    {
        UserId = userId;
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