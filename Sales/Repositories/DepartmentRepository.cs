using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.DBContexts;
using Sales.Repositories.Interfaces;

namespace Sales.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(SalesDbContext dbContext) : base(dbContext) { }

        public Task<Department> GetByName(string name)
        {
            return _dbContext.Set<Department>().FirstOrDefaultAsync(department => department.Name == name);
        }
    }
}