using System;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.Repositories.Interfaces;

namespace Sales.Services
{
 
    public class DepartmentService: GenericService<Department>, IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;


        public DepartmentService(IGenericRepository<Department> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
