using Domain.Address;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Address> AddAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        // Read by Id
        public async Task<Address> GetByIdAsync(AddressId id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        }

        // Read all
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        // Update
        public async Task<Address> UpdateAsync(Address address)
        {
            var existingAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == address.Id);
            if (existingAddress == null)
            {
                throw new ArgumentException("Address not found");
            }

            existingAddress.UpdateAddress(address.Street, address.City, address.State, address.PostalCode);
            _context.Addresses.Update(existingAddress);
            await _context.SaveChangesAsync();
            return existingAddress;
        }

        // Delete
        public async Task DeleteAsync(AddressId id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                throw new ArgumentException("Address not found");
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}