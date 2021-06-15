using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Miki.Dtos;
using Miki.Repositories.Interfaces;

namespace Miki.Controllers.Dictionary
{
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository) {
            _roleRepository = roleRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<BaseResponse<List<RoleDto>>> getAll() {
            var roleDtos = await _roleRepository.GetAllList();
            return new BaseResponse<List<RoleDto>>(roleDtos);
        }
    }
}
