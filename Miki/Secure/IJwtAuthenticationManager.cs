using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Secure
{
    public interface IJwtAuthenticationManager {
        Task<string> Authenticate(string username, string password);
    }
}
