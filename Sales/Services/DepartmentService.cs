using System;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.Repositories.Interfaces;

namespace Sales.Services
{
 
    public class DepartmentService: GenericService<Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository repository) : base(repository) { }


        //private readonly IGenericRepository<Department> _repository;


        //public DepartmentService(IGenericRepository<Department> repository) : base(repository)
        //{
        //    _repository = repository;
        //}
    }
}

//namespace Sales.Repositories
//{
//    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
//    {
//        public DepartmentRepository(SalesDbContext dbContext) : base(dbContext) { }

//        public Task<Department> GetByName(string name)
//        {
//            return _dbContext.Set<Department>().FirstOrDefaultAsync(department => department.Name == name);
//        }
//    }
//}