using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Isbn { get; set; } = default!;
        public bool Status { get; set; } = true;
    }
}
