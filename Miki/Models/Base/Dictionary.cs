using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Models.Base
{
    public class Dictionary : BaseModel
    {
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameRu { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameEn { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameKk { get; set; }

    }
}
