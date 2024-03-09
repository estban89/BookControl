using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Entities
{
    public class Orders
    {
        public string Id { get; set; }
        public DateTime DateOrder { get; set; } = DateTime.Now;
        public string CustomerId { get; set; } = default!;
        public bool Status { get; set; } = true;

        public List<OrderDetail> OrderDetails { get; set; } = default!;
        public Customer Customer { get; set; } = default!;

    }
}
