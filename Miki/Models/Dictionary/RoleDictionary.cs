using System.ComponentModel.DataAnnotations.Schema;
using Miki.Enums;
using Miki.Models.Base;

namespace Miki.Models.Dictionary
{
    public class RoleDictionary : DictionaryModel, DictionaryCode
    {
        public RoleDictionary() {
            Item.TableName = GetType().Name;
        }

        public string Code { get; set; }
    }
}
