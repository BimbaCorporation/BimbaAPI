using Domain.Addres;
using Domain.Addres;
using Domain.User;

namespace Domain.UserInfo;

public class UsersInfo
{
    public UserId UserId { get; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Address Address { get; private set; }
    public AddressId AddressId { get; private set; } 
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public UsersInfo(UserInfoId id, UserId userId, string email, string phoneNumber, Address address)
    {
        UserId = userId;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateContactInfo(string email, string phoneNumber, Address address)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        UpdatedAt = DateTime.UtcNow;
    }
}