using Domain.User;

namespace Domain.Addres;

public class Address
{
    public UserId Id { get;  private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }

    public Address(UserId id, string street, string city, string state, string postalCode)
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