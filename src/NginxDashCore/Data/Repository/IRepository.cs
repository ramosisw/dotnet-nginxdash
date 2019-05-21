using System.Collections.Generic;
using System.Linq;

namespace NginxDashCore.Data.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Entities { get; }

        void Remove(T entity);
        void Add(T entity);
        void AddRange(List<T> entities);
    }
}