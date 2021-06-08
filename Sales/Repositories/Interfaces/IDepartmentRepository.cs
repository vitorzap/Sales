using System.Threading.Tasks;
using Sales.Models;

namespace Sales.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department> GetByName(string Name);
    }
}
