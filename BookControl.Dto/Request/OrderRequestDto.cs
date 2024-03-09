using BookControl.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public class OrderRequestDto
    {
        public string Id { get; set; } = default!;
        public DateTime DateOrder { get; set; } = default!;
        public string CustomerId { get; set; } = default!;
        public bool Status { get; set; }    
        public List<OrderDetailRequestDto> OrderDetails { get; set; } = default!;
        
    }
}
