﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await base.GetAll();
            return result.Select(_ => new ArticleDto() {
                Id = _.Id,
                Name = _.Name
            }).ToList();
        }

        public async Task<ArticleDto> GetByIdDto(long id)
        {
            ArticleDto dto;
            if (!_memoryCache.TryGetValue(id, out dto)) {
                var result = await base.GetAll(_ => _.Id == id);
                if (dto != null) {
                    _memoryCache.Set(id, dto,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3)));
                }

                return result.Select(_ => new ArticleDto() {
                    Id = _.Id,
                    Name = _.Name
                }).FirstOrDefault();
            }

            return dto;
        }
    }
}
