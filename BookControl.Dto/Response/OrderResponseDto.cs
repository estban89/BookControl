using BookControl.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public record OrderResponseDto(string Id, DateTime DateOrder, CustomerResponseDto? Customer, List<OrderDetailResponseDto>? OrderDetails, bool Status)
    {
    }
}
