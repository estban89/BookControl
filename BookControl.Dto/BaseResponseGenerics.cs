using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto
{
    public class BaseResponseGenerics<T>: BaseResponse
    {
        public T? Data { get; set; }
    }
}
