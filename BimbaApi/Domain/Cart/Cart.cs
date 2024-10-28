using Domain.MenuItem;
using Domain.User;

namespace Domain.Cart;

public class Cart
{
    public UserId UserId { get; }
    public List<CartItem.CartItem> Items { get; set; }

    public Cart(UserId userId)
    {
        UserId = userId;
        Items = new List<CartItem.CartItem>();
    }

    public void AddItem(MenuItem.MenuItem item, int quantity)
    {
        var cartItem = Items.FirstOrDefault(i => i.MenuItemId == item.Id);
        if (cartItem == null)
        {
            Items.Add(new CartItem.CartItem(item.Id, quantity)); // Не потрібно CartId тут
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