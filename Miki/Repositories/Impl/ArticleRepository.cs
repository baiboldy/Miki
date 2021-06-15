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
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        private readonly IMemoryCache _memoryCache;

        public ArticleRepository(MainDbContext context, IMemoryCache memoryCache) : base(context) {
            _memoryCache = memoryCache;
        }
        public async Task<List<ArticleDto>> GetAllList() {
            if (!_memoryCache.TryGetValue(MethodBase.GetCurrentMethod().Name, out List<ArticleDto> dtoResult)) {
                var result = await base.GetAll();
                dtoResult = result.Select(_ => new ArticleDto()
                {
                    Id = _.Id,
                    Name = _.Name
                }).ToList();

                if (dtoResult.Count > 0)
                {
                    _memoryCache.Set(MethodBase.GetCurrentMethod().Name, dtoResult,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
                }

                return dtoResult;
            }

            return dtoResult;
        }

        public async Task<ArticleDto> GetByIdDto(long id)
        {
            if (!_memoryCache.TryGetValue(MethodBase.GetCurrentMethod().Name, out ArticleDto dto)) {
                var result = await base.GetAll(_ => _.Id == id);
                dto = result.Select(_ => new ArticleDto() {
                    Id = _.Id,
                    Name = _.Name
                }).FirstOrDefault();
                if (dto != null) {
                    _memoryCache.Set(MethodBase.GetCurrentMethod().Name, dto,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
                }

                return dto;
            }

            return dto;
        }
    }
}
