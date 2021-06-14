using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models
{
    public class Article : BaseModel
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name must be between 2 and 50 characters")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
