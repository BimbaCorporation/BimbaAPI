using Domain.Address;
using Domain.User;

namespace Domain.UserInfo;

public class UserInfo
{
    public UserInfoId Id { get; }
    public UserId UserId { get; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Address.Address Address { get; private set; }
    public AddressId AddressId { get; private set; } // Додайте це
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public UserInfo(UserInfoId id, UserId userId, string email, string phoneNumber, Address.Address address)
    {
        Id = id;
        UserId = userId;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        AddressId = address != null ? address.Id : AddressId.Empty; // Присвоюємо AddressId
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateContactInfo(string email, string phoneNumber, Address.Address address)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        AddressId = address != null ? address.Id : AddressId.Empty; // Оновлюємо AddressId
        UpdatedAt = DateTime.UtcNow;
    }
}