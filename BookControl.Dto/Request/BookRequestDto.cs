using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Dto.Response
{
    public class BookRequestDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string Isbn { get; set; } = default!;
        public bool Status { get; set; } = default!;

    }
}
