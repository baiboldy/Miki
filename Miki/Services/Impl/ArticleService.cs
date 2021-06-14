using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Repositories.Interfaces;
using Miki.Services.Interface;

namespace Miki.Services.Impl
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IUnitOfWork unitOfWork, IArticleRepository articleRepository) {
            _unitOfWork = unitOfWork;
            _articleRepository = articleRepository;
        }
        public async Task<BaseReponse<List<ArticleDto>>> getAll() {
            using (var trans = _unitOfWork.BeginTransaction()) {
                var all = await _articleRepository.GetAllList();
                trans.Commit();
                return new BaseReponse<List<ArticleDto>>(all);
            }
        }
    }
}
