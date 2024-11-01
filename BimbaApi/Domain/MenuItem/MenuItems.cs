namespace Domain.MenuItem;

public class MenuItems
{
    public MenuItemId Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; }

    public MenuItems(MenuItemId id, string name, string description, decimal price, bool isAvailable)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
    }

    public void UpdateAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }
}
