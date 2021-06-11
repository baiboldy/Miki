using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Services.Interface;

namespace Miki.Services.Impl
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<BaseReponse<List<ArticleDto>>> getAll() {
            throw new Exception();
        }
    }
}
