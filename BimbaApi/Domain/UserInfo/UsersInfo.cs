using Domain.User;
using Domain.Addres;

namespace Domain.UserInfo
{
    public class UsersInfo
    {
        public UserInfoId UserInfoId { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public AddressId AddressId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Constructor for business logic
        public UsersInfo(UserInfoId userId, string email, string phoneNumber, Address address)
        {
            UserInfoId = userId;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Parameterless constructor for EF Core
        private UsersInfo() { }

        public void UpdateContactInfo(string email, string phoneNumber, Address address)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}