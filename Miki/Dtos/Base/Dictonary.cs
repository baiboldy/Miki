using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Dtos.Base
{
    public class DictonaryDto : BaseDto, ItemDto
    {
        public string NameRu { get; set; }
        public string NameKk { get; set; }
        public string NameEn { get; set; }
        public long ItemId { get; set; }
    }
}
