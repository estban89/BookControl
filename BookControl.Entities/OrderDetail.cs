using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Entities
{
    public class OrderDetail
    {
        public string Id { get; set; } = default!;
        public string OrdersId { get; set; } = default!;
        public string BooksId { get; set; } = default!;

        public Orders Orders { get; set; } = default!;
        public Book Books { get; set; } = default!;

    }
}
