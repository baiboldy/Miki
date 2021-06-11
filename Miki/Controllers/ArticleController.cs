using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;

namespace Miki.Controllers
{
    [Authorize(Roles = "user")]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly MainDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(MainDbContext context, IUnitOfWork unitOfWork) {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<BaseReponse<List<ArticleDto>>> GetArticle()
        {
            var userIdentity = HttpContext.User.Identity;
            var result = await _unitOfWork.ArticleRepository.GetAll();
            var dtoResult = result.Select(_ => new ArticleDto {
                Id = _.Id,
                Name =  _.Name
            }).ToList();

            return new BaseReponse<List<ArticleDto>>(dtoResult);
        }

        [HttpPost("add")]
        public async Task<long> InsertArticle(ArticleDto articleDto) {
            var article = new Article {
                Name = articleDto.Name
            }; 
            await _unitOfWork.ArticleRepository.Create(article);
            await _unitOfWork.Save();

            return article.Id;
        }
    }
}
