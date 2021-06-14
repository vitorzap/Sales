using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Sales.Models;
using System.Linq;
using System.Linq.Expressions;

namespace Sales.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int? id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int? id);
        bool Exists(int? id);
    }
}

