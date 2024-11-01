using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure.Persistence;

public static class ConfigurePersistence
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var dataSourceBuild = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("Default"));
        dataSourceBuild.EnableDynamicJson();
        var dataSource = dataSourceBuild.Build();

        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(
                    dataSource,
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseSnakeCaseNamingConvention()
                .ConfigureWarnings(w => w.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning)));

        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        services.AddScoped<IUserRepository>(provider => provider.GetRequiredService<UserRepository>());
        services.AddScoped<IUserQueries>(provider => provider.GetRequiredService<UserRepository>());

        services.AddScoped<UsersInfoRepository>();
        services.AddScoped<IUsersInfoRepository>(provider => provider.GetRequiredService<UsersInfoRepository>());
        services.AddScoped<IUsersInfoQueries>(provider => provider.GetRequiredService<UsersInfoRepository>());

        services.AddScoped<AdressRepository>();
        services.AddScoped<IAdressRepository>(provider => provider.GetRequiredService<AdressRepository>());
        services.AddScoped<IAdressQueries>(provider => provider.GetRequiredService<AdressRepository>());
        
        services.AddScoped<CartItemRepository>();
        services.AddScoped<ICartItemRepository>(provider => provider.GetRequiredService<CartItemRepository>());
        services.AddScoped<ICartItemQueries>(provider => provider.GetRequiredService<CartItemRepository>());
        
        services.AddScoped<CartRepository>();
        services.AddScoped<ICartRepository>(provider => provider.GetRequiredService<CartRepository>());
        services.AddScoped<ICartQueries>(provider => provider.GetRequiredService<CartRepository>());
        
        services.AddScoped<MenuItemRepository>();
        services.AddScoped<IMenuItemRepository>(provider => provider.GetRequiredService<MenuItemRepository>());
        services.AddScoped<IMenuItemQueries>(provider => provider.GetRequiredService<MenuItemRepository>());
        
        services.AddScoped<OrderHistoryRepository>();
        services.AddScoped<IOrderHistoryRepository>(provider => provider.GetRequiredService<OrderHistoryRepository>());
        services.AddScoped<IOrderHistoryQueries>(provider => provider.GetRequiredService<OrderHistoryRepository>());
        
        services.AddScoped<OrderItemRepository>();
        services.AddScoped<IOrderItemRepository>(provider => provider.GetRequiredService<OrderItemRepository>());
        services.AddScoped<IOrderItemQueries>(provider => provider.GetRequiredService<OrderItemRepository>());
        
        services.AddScoped<OrderRepository>();
        services.AddScoped<IOrderRepository>(provider => provider.GetRequiredService<OrderRepository>());
        services.AddScoped<IOrderQueries>(provider => provider.GetRequiredService<OrderRepository>());
    }
}