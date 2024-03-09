using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public record CustomerResponseDto(string Id, string Name, string LastName, string Dni, int Age)
    {
    }
}
