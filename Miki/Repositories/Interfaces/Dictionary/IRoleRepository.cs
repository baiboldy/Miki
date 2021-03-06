using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;
using Miki.Models;
using Miki.Models.Dictionary;

namespace Miki.Repositories.Interfaces
{
    public interface IRoleRepository : IBaseRepository<RoleDictionary>, IRepository<RoleDto>
    {
    }
}
