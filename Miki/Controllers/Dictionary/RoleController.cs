using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Models.Dictionary;
using Miki.Repositories.Interfaces;

namespace Miki.Controllers.Dictionary
{
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork
            ) {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<BaseResponse<List<RoleDto>>> getAll() {
            var roleDtos = await _roleRepository.GetAllList();
            return new BaseResponse<List<RoleDto>>(roleDtos);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task add([FromBody] RoleDto roleDto) {
            using (var unitOfWork = _unitOfWork.BeginTransaction()) {
                var role = new RoleDictionary {
                    NameRu = roleDto.NameRu,
                    NameEn = roleDto.NameEn,
                    NameKk = roleDto.NameKk,
                    Code = roleDto.Code
                };
                await _roleRepository.Create(role);
                await _roleRepository.Save();
                await unitOfWork.CommitAsync();
            }
        }
    }
}
