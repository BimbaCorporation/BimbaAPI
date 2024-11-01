using System;

namespace Domain.Addres;

public record AddressId(Guid Value)
{
    public static AddressId New() => new(Guid.NewGuid());
    public static AddressId Empty => new(Guid.Empty);
    public override string ToString() => Value.ToString();
}