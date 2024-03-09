using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Entities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Dni { get; set; } = default!;
        public int Age { get; set; } = default!;
    }
}
