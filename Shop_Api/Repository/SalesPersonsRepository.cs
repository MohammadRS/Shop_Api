using Microsoft.EntityFrameworkCore;
using Shop_Api.Contracts;
using Shop_Api.Data;
using Shop_Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Api.Repository
{
    public class SalesPersonsRepository : ISalesPersonsRepository
    {
        private readonly ShopContext _context;

        public SalesPersonsRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<SalesPersons> Add(SalesPersons sales)
        {
            await _context.SalesPersons.AddAsync(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPersons> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(x => x.SalesPersonId == id);
        }

        public IEnumerable<SalesPersons> GetAll()
        {
            return _context.SalesPersons.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.SalesPersons.AnyAsync(x => x.SalesPersonId == id);
        }

        public async Task<SalesPersons> Remove(int id)
        {
            var sales = await _context.SalesPersons.SingleAsync(x => x.SalesPersonId == id);
            _context.SalesPersons.Remove(sales);
            await _context.SaveChangesAsync();
            return sales;
        }

        public async Task<SalesPersons> Update(SalesPersons sales)
        {
            _context.Update(sales);
            await _context.SaveChangesAsync();
            return sales;
        }
    }
}
