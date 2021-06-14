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
        [DataType(DataType.EmailAddress)]
        [Required]
        [StringLength(maximumLength:50, MinimumLength = 5)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string Lastname { get; set; }
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public RoleDictionary Role { get; set; }

        public string FullName {
            get { return $"{Lastname} {Name} {Surname}"; }
        }
    }
}
