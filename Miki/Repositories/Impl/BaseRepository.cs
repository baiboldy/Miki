using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Miki.AppDbContext;
using Miki.Repositories.Interfaces;

namespace Miki.Repositories.Impl
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly MainDbContext _context;
        internal DbSet<T> dbSet;

        public BaseRepository(MainDbContext context) {
            _context = context;
            this.dbSet = context.Set<T>();
        }
        public async Task Create(T item) {
            await dbSet.AddAsync(item);
        }

        public virtual void Update(T item) {
            dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public virtual async void Delete(long id) {
            var entity = await dbSet.FindAsync(id);
            Delete(entity);
        }

        public virtual void Delete(T item) {
            if (_context.Entry(item).State == EntityState.Detached) {
                dbSet.Attach(item);
            }

            dbSet.Remove(item);
        }

        public virtual async Task<IQueryable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "") {
            IQueryable<T> query = dbSet;

            if (filter != null) {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries)) {
                query = query.Include(includeProperty);
            }

            if (orderBy != null) {
                var result = orderBy(query);
                return result;
            }

            var resultList = query;
            return resultList;
        }

        public virtual async Task<T> GetById(long id) {
            var result = await dbSet.FindAsync(id);
            return result;
        }

    }
}
