using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;

namespace Miki.Repositories.Interfaces
{
    public interface IRepository<Dto> where Dto : class {
        Task<List<Dto>> GetAllList();
        Task<Dto> GetByIdDto(long id);
    }
}
