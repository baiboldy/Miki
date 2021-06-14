using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos;

namespace Miki.Services
{
    public interface IUserService {
        Task<BaseResponse<bool>> register(UserDto user);

    }
}