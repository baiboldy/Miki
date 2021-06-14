using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;
using Miki.Services.Interface;

namespace Miki.Controllers
{
    [Authorize(Roles = "user,admin")]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly MainDbContext _context;
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleService _articleService;
        private readonly IMemoryCache _memoryCache;

        public ArticleController(MainDbContext context, IArticleRepository articleRepository, IUnitOfWork unitOfWork, IArticleService articleService, IMemoryCache memoryCache) {
            _context = context;
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _articleService = articleService;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public async Task<BaseResponse<List<ArticleDto>>> GetArticle()
        {
            var userIdentity = HttpContext.User.Identity;
            var result = await _articleRepository.GetAllList();
            return new BaseResponse<List<ArticleDto>>(result);
        }

        [HttpGet("id={id}")]
        [AllowAnonymous]
        public async Task<BaseResponse<ArticleDto>> GetById(long id) {
            var dto = await _articleService.getById(id);
            return dto;
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
