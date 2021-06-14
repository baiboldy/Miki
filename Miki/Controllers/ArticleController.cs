using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;

namespace Miki.Controllers
{
    [Authorize(Roles = "user,admin")]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly MainDbContext _context;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(MainDbContext context, IArticleRepository articleRepository, IUnitOfWork unitOfWork) {
            _context = context;
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<BaseReponse<List<ArticleDto>>> GetArticle()
        {
            var userIdentity = HttpContext.User.Identity;
            var result = await _articleRepository.GetAllList();
            return new BaseReponse<List<ArticleDto>>(result);
        }

        [HttpPost("add")]
        public async Task<long> InsertArticle([FromBody] ArticleDto articleDto)
        {
            using (var trans = _unitOfWork.BeginTransaction()) {
                var article = new Article
                {
                    Name = articleDto.Name
                };
                await _articleRepository.Create(article);
                await _articleRepository.Save();
                Console.WriteLine(article.Id);
                await trans.CommitAsync();
                return article.Id;
            }
        }
        [HttpPost("update")]
        public async Task UpdateArticle([FromBody] ArticleDto articleDto)
        {
            using (var trans = _unitOfWork.BeginTransaction())
            {
                var article = new Article
                {
                    Id = articleDto.Id,
                    Name = articleDto.Name
                };
                _articleRepository.Update(article);
                await _articleRepository.Save();
                await trans.CommitAsync();
            }
        }
    }
}
