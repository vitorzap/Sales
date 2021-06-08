using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Sales.Models;

namespace Sales.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int? id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int? id);
        bool Exists(int? id);
    }
}

