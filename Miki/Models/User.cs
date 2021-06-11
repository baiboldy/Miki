using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }        
        public string Lastname { get; set; }
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public RoleDictionary Role { get; set; }
    }
}
