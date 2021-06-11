using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public BaseRepository<Article> ArticleRepository {
            get {
                if (this.articleRepository == null) {
                    this.articleRepository = new BaseRepository<Article>(_context);
                }

                return this.articleRepository;
            }
        }

        public BaseRepository<User> UserRepository {
            get {
                if (userRepository == null) {
                    userRepository = new BaseRepository<User>(_context);
                }

                return userRepository;
            }
        }


        public async Task Save() {
            await _context.SaveChangesAsync();
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
