using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miki.Dtos
{
    public class BaseResponse<T>
    {
        public T Body { get; set; }

        public BaseResponse(T body) {
            Body = body;
        }

        public BaseResponse(bool hasError, string error) {
            HasError = hasError;
            Error = error;
        }

        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
