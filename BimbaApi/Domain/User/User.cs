using Domain.UserInfo;
using Domain.Order;

namespace Domain.User
{
    public class User
    {
        public UserId Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string FullName => $"{FirstName} {LastName}";

        public virtual UsersInfo? UsersInfo { get; private set; }
        public  UserInfoId UsersInfoId { get; set; }
        public virtual List<Orders> Orders { get; private set; } = new();

        public User(UserId id, string firstName, string lastName, UsersInfo usersInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UsersInfo = usersInfo;
            Orders = new List<Orders>();
        }

        private User() { }

        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}