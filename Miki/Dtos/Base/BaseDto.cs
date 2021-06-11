using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Dtos.Base
{
    public class BaseDto : IBaseDto
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
