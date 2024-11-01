using Domain.User;
using Domain.UserInfo;

namespace Domain.Addres
{
    public class Address
    {
        public AddressId AddressId { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public virtual UsersInfo? UsersInfo { get; private set; }
        public UserInfoId UsersInfoId { get; set; }

        // Публічний конструктор для ініціалізації
        private Address(AddressId id, string street, string city, string state, string postalCode)
        {
            AddressId = id;
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        // Приватний конструктор без параметрів для EF Core
        private Address() { }

        public void UpdateAddress(string street, string city, string state, string postalCode)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
        }
    }
}