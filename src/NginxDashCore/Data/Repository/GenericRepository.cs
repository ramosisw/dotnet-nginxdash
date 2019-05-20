using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NginxDashCore.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public IQueryable<T> Entities => _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }
    }
}