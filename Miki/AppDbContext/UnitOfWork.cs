using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Impl;

namespace Miki.AppDbContext
{
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private readonly MainDbContext _context;
        private BaseRepository<Article> articleRepository;
        private BaseRepository<User> userRepository;

        public UnitOfWork(MainDbContext context) {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction() {
           var result =  _context.Database.BeginTransaction();
           return result;
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
