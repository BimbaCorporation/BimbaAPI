using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AdressRepository (ApplicationDbContext context) : IAdressQueries, IAdressRepository
{
    
    
    
}