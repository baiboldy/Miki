using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Miki.Models.Base;

namespace Miki.Models
{
    public class BaseModel : IBaseModel
    {
        [Key]
        public long Id { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
