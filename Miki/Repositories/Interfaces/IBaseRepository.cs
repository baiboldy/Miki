using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Miki.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T:class {
        Task Create(T item);
        void Update(T item);
        void Delete(long id);
        void Delete(T item);
        Task<IQueryable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> GetById(long id);
        Task Save();
    }
}
