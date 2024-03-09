using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public record BookResponseDto( string Id, string Name, string Author, string Isbn, bool Status)
    {
    }
}
