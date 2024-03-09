using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public class CustomerRequestDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Dni { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
