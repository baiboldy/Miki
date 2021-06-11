using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Dtos.Base
{
    public interface IBaseDto
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
