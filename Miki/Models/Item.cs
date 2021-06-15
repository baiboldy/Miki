using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Miki.Enums;

namespace Miki.Models
{
    public class Item : BaseModel
    {
        public ItemType ItemType { get; set; } 
        public string TableName { get; set; }
    }
}
