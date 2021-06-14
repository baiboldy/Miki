using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Models;
using Miki.Repositories.Interfaces;
using Miki.Secure;

namespace Miki.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IJwtAuthenticationManager jwtAuthenticationManager, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<BaseReponse<bool>> register(UserDto userDto) {
            var hashed = Helpers.Hashing.ToMD5(userDto.Password);
            userDto.Password = hashed;

            var results = await _userRepository.GetAll(_ => _.Email == userDto.Email && _.Password == userDto.Password);
            if (results.Count() > 1)
            {
                return new BaseReponse<bool>(true, "Такой пользователь уже сущетсвует");
            }

            await _userRepository.Create(new User()
            {
                Name = userDto.Name,
                Password = userDto.Password,
                Email = userDto.Email,
                Lastname = userDto.Lastname,
                Surname = userDto.Surname,
                RoleId = userDto.Role.Id
            });

            return new BaseReponse<bool>(false, "Пользователь успешно создан");

        }
    }
}
