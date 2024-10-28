namespace Domain.OrderHistory;

public record OrderHistoryId(Guid Value)
{
    public static OrderHistoryId New() => new(Guid.NewGuid());
    public static OrderHistoryId Empty() => new(Guid.Empty);
    public override string ToString() => Value.ToString();
}