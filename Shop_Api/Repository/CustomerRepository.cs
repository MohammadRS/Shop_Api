using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Shop_Api.Contracts;
using Shop_Api.Data;
using Shop_Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private ShopContext _context;
        private IMemoryCache _cache;

        public CustomerRepository(ShopContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }


        public async Task<Customer> Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<int> CountCustomer()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<Customer> Find(int id)
        {
            return await _context.Customers.Include(x => x.Orders).SingleOrDefaultAsync(x => x.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Customers.AnyAsync(x => x.CustomerId == id);
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _context.Customers.SingleAsync(x => x.CustomerId == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async  Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
