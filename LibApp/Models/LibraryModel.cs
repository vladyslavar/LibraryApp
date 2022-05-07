using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LibraryModel
    {
        public int ReaderID { get; set; }
        public string ReaderName { get; set; }
        public string ReaderSurname { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookTheme { get; set; }
        public int? BookYear { get; set; }
        public int? BookCurrReaderId { get; set; }
        
    }
}
