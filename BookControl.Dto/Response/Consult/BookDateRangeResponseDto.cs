using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response.Consult
{
    public record BookDateRangeResponseDto(string Id, DateTime DateOrder, bool Status)
    {
    }
}
