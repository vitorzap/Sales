using System;
using Sales.Services.Interfaces;
using Sales.Repositories.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Sales.Models;
using Sales.DBContexts;
using System.Linq.Expressions;

namespace Sales.Services
{
    public class GenericService<T>: IGenericService<T> where T : BaseEntity
    {
        protected readonly IGenericRepository<T> _repository;


        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }


        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }
        public virtual async Task<T> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var department = await _repository.GetById(id);
            if (department == null)
            {
                return null;
            }

            return department;

        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public virtual async Task Insert(T entity)
        {
            await _repository.Insert(entity);
        }
        public virtual async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
        public virtual async Task Delete(int? id)
        {
            await _repository.Delete(id);
        }
        public virtual bool Exists(int? id)
        {
            return true;
        }
    }
}