using System.Threading.Tasks;
using Sales.Models;

namespace Sales.Repositories.Interfaces
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<Seller> GetByName(string Name);
    }
}