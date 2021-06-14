using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos.Base;
using Miki.Models;
using Newtonsoft.Json;

namespace Miki.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public RoleDto Role { get; set; }
    }
}
