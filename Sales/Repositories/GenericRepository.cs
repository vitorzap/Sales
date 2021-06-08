using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Sales.Models;
using Sales.Repositories.Interfaces;
using Sales.DBContexts;

namespace Sales.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly SalesDbContext _dbContext;
        private DbSet<T> _entities;
        string errorMessage = string.Empty;

        public GenericRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            //return _entities.AsEnumerable();
            return await _entities.ToListAsync<T>();
        }
        public async Task<T> GetById(int? id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.CreatedAt = DateTime.Now;
            await _entities.AddAsync(entity);
            //entities.Add(entity);
            //context.SaveChanges();
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entity.UpdatedAt = DateTime.Now;
            _dbContext.Update(entity);
            //context.Update(entity);
            //context.SaveChanges();
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int? id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            T entity = await _entities.SingleOrDefaultAsync(s => s.Id == id);

            //var department = await _context.Department.FindAsync(id);
            //_context.Department.Remove(department);
            //await _context.SaveChangesAsync();
            //var department = _departmentRepository.GetById(id);


            //await _context.SaveChangesAsync();
            _entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public  bool Exists(int? id)
        {
            if (id == null) throw new ArgumentNullException("entity");

            return _entities.Any(s => s.Id == id);
        }

    }
}