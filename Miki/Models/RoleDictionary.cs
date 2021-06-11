using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Miki.Models.Base;

namespace Miki.Models
{
    public class RoleDictionary : Dictionary, DictionaryCode
    {
        public string Code { get; set; }
    }
}
