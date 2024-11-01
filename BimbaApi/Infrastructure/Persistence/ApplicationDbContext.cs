using System.Reflection;
using Domain.Addres;
using Domain.Addres;
using Domain.Cart;
using Domain.CartItem;
using Domain.MenuItem;
using Domain.Order;
using Domain.OrderHistory;
using Domain.OrderItem;
using Domain.User;
using Domain.UserInfo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItems> CartItems { get; set; }
    public DbSet<MenuItems> MenuItems { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderHistory> OrderHistoryes { get; set; }
    public DbSet<UsersInfo> UserInfos { get; set; } 

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}