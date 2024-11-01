using Domain.MenuItem;
using Domain.MenuItem;
using Domain.MenuItem;
using Domain.Order;
using Domain.OrderHistory;
using Domain.UserInfo;

namespace Domain.User;

public class User
{
    public UserId Id { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string FullName => $"{FirstName} {LastName}";
    public UsersInfo UsersInfo { get; private set; }
    public List<Orders> Orders { get; private set; }

    public User(UserId id, string firstName, string lastName, UsersInfo usersInfo)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UsersInfo = usersInfo;
        Orders = new List<Orders>();
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void SetUserInfo(UserInfo.UsersInfo usersInfo)
    {
        UsersInfo = usersInfo;
    }
}

