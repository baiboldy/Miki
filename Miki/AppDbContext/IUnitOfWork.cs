using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Miki.Models;
using Miki.Repositories.Impl;

namespace Miki.AppDbContext
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();
    }
}
