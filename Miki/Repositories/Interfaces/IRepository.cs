using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;

namespace Miki.Repositories.Interfaces
{
    public interface IRepository<Dto, Model> where Model : class where Dto : class {
        Task<List<Dto>> GetAll();
        Task<Dto> GetById(long id);

    }
}
