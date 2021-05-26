using Microsoft.EntityFrameworkCore;
using Shop_Api.Contracts;
using Shop_Api.Data;
using Shop_Api.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;
        }


        public async Task<Products> Add(Products products)
        {
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task<Products> Find(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _context.Products.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Products.AnyAsync(x => x.ProductId == id);
        }

        public async Task<Products> Remove(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Update(Products products)
        {
            _context.Update(products);
            await _context.SaveChangesAsync();
            return products;
        }
    }
}
