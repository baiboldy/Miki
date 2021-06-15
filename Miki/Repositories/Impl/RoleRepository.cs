using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;

namespace Miki.Repositories.Impl
{
    /// <summary>
    /// Репозиторий ролей пользователей
    /// </summary>
    public class RoleRepository : BaseRepository<RoleDictionary>, IRoleRepository
    {
        private readonly IMemoryCache _memoryCache;

        public RoleRepository(
            MainDbContext context,
            IMemoryCache memoryCache
            ) : base(context) {
            _memoryCache = memoryCache;
        }

        public async Task<List<RoleDto>> GetAllList() {
            if (!_memoryCache.TryGetValue(MethodBase.GetCurrentMethod().Name, out List<RoleDto> roleDtos)) {
                var result = await base.GetAll();
                roleDtos = result.Select(_ => new RoleDto {
                    Id = _.Id,
                    IsDeleted = _.IsDeleted,
                    Code = _.Code,
                    NameRu = _.NameRu,
                    NameEn = _.NameEn,
                    NameKk = _.NameKk
                }).ToList();

                if (roleDtos.Count > 0) {
                    _memoryCache.Set(MethodBase.GetCurrentMethod().Name, roleDtos,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
                }

                return roleDtos;
            }

            return roleDtos;

        }

        public Task<RoleDto> GetByIdDto(long id) {
            throw new NotImplementedException();
        }
    }
}
