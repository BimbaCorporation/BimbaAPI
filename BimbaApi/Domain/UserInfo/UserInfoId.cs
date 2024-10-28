namespace Domain.UserInfo;

public record UserInfoId(Guid Value)
{
    public static UserInfoId New() => new(Guid.NewGuid());
    public static UserInfoId Empty() => new(Guid.Empty);
    public override string ToString() => Value.ToString();
}