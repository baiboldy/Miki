using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;

namespace Miki.Services.Interface
{
    public interface IArticleService {
        Task<BaseReponse<List<ArticleDto>>> getAll();
    }
}
