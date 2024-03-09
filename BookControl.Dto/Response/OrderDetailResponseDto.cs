using BookControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public record OrderDetailResponseDto(string Id, BookResponseDto Books)
    {

    }
}
