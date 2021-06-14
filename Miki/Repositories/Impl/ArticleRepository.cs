using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;

namespace Miki.Repositories.Impl
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(MainDbContext context) : base(context) {
        }
        public async Task<List<ArticleDto>> GetAllList() {
            var result = await base.GetAll(filter: _ => _.IsDeleted == true);
            return result.Select(_ => new ArticleDto() {
                Id = _.Id,
                Name = _.Name
            }).ToList();
        }

        public async Task<ArticleDto> GetByIdDto(long id) {
            var result = await base.GetAll(_ => _.Id == id);
            return result.Select(_ => new ArticleDto() {
                Id = _.Id,
                Name = _.Name
            }).FirstOrDefault();
        }
    }
}
