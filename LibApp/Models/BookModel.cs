using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Theme { get; set; }
        public int? Year { get; set; }
        public int? CurrReaderId { get; set; }
    }
}
