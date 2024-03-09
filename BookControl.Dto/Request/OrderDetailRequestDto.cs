using BookControl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Request
{
    public class OrderDetailRequestDto
    {
        public string Id { get; set; } = default!;
        public string OrderId { get; set; } = default!;
        public string BooksId { get; set; } = default!;
    }
}
