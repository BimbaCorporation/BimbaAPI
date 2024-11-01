namespace Domain.MenuItem;

public record MenuItemId(Guid Value)
{
    public static MenuItemId New() => new(Guid.NewGuid());
    public static MenuItemId Empty() => new(Guid.Empty);
    public override string ToString() => Value.ToString();
    
}