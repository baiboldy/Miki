using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Miki.Enums;
using Newtonsoft.Json;

namespace Miki.Models.Base
{
    public class DictionaryModel : BaseModel
    {
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameRu { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameEn { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string NameKk { get; set; }

        [ForeignKey("Item")]
        public long ItemId { get; set; }
        [JsonIgnore]
        public Item Item { get; set; } = new Item() {
            ItemType = ItemType.Dictionary
        };

    }
}
