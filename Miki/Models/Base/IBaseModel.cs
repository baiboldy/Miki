using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models.Base
{
    public interface IBaseModel
    {
        [Key]
        long Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
