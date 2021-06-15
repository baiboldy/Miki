using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Dtos.Base;

namespace Miki.Dtos
{
    public class RoleDto : DictonaryDto, IDictionaryCode
    {
        public string Code { get; set; }
    }
}
