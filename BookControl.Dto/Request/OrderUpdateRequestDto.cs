using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Request
{
    public class OrderUpdateRequestDto
    {
        public string Id { get; set; } = default!;
        public bool Status { get; set; }
    }
}
