using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.DBContexts;
using Sales.Repositories.Interfaces;
namespace Sales.Repositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {
        public SellerRepository(SalesDbContext dbContext) : base(dbContext) { }

        public Task<Seller> GetByName(string name)
        {
            return _dbContext.Set<Seller>().FirstOrDefaultAsync(seller => seller.Name == name);
        }

    }
}