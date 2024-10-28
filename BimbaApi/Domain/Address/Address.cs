namespace Domain.Address;

public class Address
{
    public AddressId Id { get; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }

    public Address(AddressId id, string street, string city, string state, string postalCode)
    {
        Id = id;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
    }

    public void UpdateAddress(string street, string city, string state, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
    }
}