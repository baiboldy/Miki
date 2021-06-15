using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;
using Miki.Services;

namespace Miki.Repositories.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context)
        {
        }
        public async Task<List<UserDto>> GetAllList()
        {
            var result = await base.GetAll();
            return result.Select(_ => new UserDto()
            {
                Email = _.Email,
                Id = _.Id,
                IsDeleted = _.IsDeleted,
                Lastname = _.Lastname,
                Name = _.Name,
                Password = _.Password,
                Role = new RoleDto() {
                    Id = _.Role.Id,
                    NameRu = _.Role.NameRu,
                    NameEn = _.Role.NameEn,
                    NameKk = _.Role.NameKk
                },
                Surname = _.Surname
            }).ToList();
        }

        public async Task<UserDto> GetByIdDto(long id)
        {
            var result = await base.GetAll(_ => _.Id == id);
            return result.Select(_ => new UserDto()
            {
                Email = _.Email,
                Id = _.Id,
                IsDeleted = _.IsDeleted,
                Lastname = _.Lastname,
                Name = _.Name,
                Role = new RoleDto()
                {
                    Id = _.Role.Id,
                    NameRu = _.Role.NameRu,
                    NameEn = _.Role.NameEn,
                    NameKk = _.Role.NameKk
                },
                Surname = _.Surname
            }).FirstOrDefault();
        }

    }
}
