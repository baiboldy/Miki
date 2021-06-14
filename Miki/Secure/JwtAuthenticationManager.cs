using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Miki.AppDbContext;
using Miki.Dtos;
using Miki.Helpers;
using Miki.Repositories.Interfaces;

namespace Miki.Secure
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public JwtAuthenticationManager(IConfiguration configuration, IUnitOfWork unitOfWork, IUserRepository userRepository) {
            _key = configuration.GetValue<string>("AuthKey");
             _unitOfWork = unitOfWork;
             _userRepository = userRepository;
        }

        public async Task<string> Authenticate(string username, string password) {
            var hashedPassword = Hashing.ToMD5(password);
            var results = await _userRepository.GetAll(
                _ => _.Email == username && _.Password == hashedPassword);
            var result = results.Select(_ => new UserDto {
                Id = _.Id,
                Name = _.Name,
                Email = _.Email,
                Surname = _.Surname,
                Lastname = _.Lastname,
                Role = new RoleDto() {
                    Id = _.Id,
                    Code = _.Role.Code,
                    NameRu = _.Role.NameRu
                }
            }).FirstOrDefault();
            if (result == null) {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Sid, result.Id.ToString()), 
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, result.Role.Code), 
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
