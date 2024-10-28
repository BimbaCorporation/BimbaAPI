using Domain.OrderHistory;
using Domain.Order;
using Domain.UserInfo;
using Domain.MenuItem;
using Domain.MenuItem;
using Domain.MenuItem;

namespace Domain.User;

public class User
{
    public UserId Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public string FullName => $"{FirstName} {LastName}";
    public UserInfo.UserInfo UserInfo { get; private set; }
    public List<Order.Order> Orders { get; private set; }

    public User(UserId id, string firstName, string lastName, UserInfo.UserInfo userInfo)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserInfo = userInfo;
        Orders = new List<Order.Order>();
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetUserInfo(UserInfo.UserInfo userInfo)
    {
        UserInfo = userInfo;
    }
}

