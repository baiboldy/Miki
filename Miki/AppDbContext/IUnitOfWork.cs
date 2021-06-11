using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Models;
using Miki.Repositories.Impl;

namespace Miki.AppDbContext
{
    public interface IUnitOfWork
    {
        BaseRepository<Article> ArticleRepository { get; }
        BaseRepository<User> UserRepository { get; }
        Task Save();
    }
}
