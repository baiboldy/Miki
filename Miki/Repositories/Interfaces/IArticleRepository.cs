using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;
using Miki.Models;

namespace Miki.Repositories.Interfaces
{
    public interface IArticleRepository : IBaseRepository<Article>, IRepository<ArticleDto>
    {
    }
}
