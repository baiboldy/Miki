using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models.Base
{
    public interface DictionaryCode
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 50 characters")]
        string Code { get; set; }
    }
}
