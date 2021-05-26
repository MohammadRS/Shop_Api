using Shop_Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop_Api.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Task<Products> Add(Products products);
        Task<Products> Find(int id);
        Task<Products> Update(Products products);
        Task<Products> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
