using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Secure;
using Miki.Services;

namespace Miki.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(IJwtAuthenticationManager jwtAuthenticationManager, IUnitOfWork unitOfWork, IUserService userService) {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Login(string email, string password) {
            var token = _jwtAuthenticationManager.Authenticate(email, password);
            if (token == null) {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<BaseReponse<bool>> Register(UserDto userDto) {
            var result = await _userService.register(userDto);
            return result;
        }


    }
}
