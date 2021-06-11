using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Dtos
{
    public class BaseReponse<T>
    {
        public T Body { get; set; }

        public BaseReponse(T body) {
            Body = body;
        }

        public BaseReponse(bool hasError, string error) {
            HasError = hasError;
            Error = error;
        }

        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
