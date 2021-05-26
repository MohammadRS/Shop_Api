using Shop_Api.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop_Api.Contracts
{
    public interface ISalesPersonsRepository
    {
        IEnumerable<SalesPersons> GetAll();
        Task<SalesPersons> Add(SalesPersons sales);
        Task<SalesPersons> Find(int id);
        Task<SalesPersons> Update(SalesPersons sales);
        Task<SalesPersons> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
