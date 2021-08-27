using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Training.Entities
{
  public  class BookAuthor
    {
        public Book book { get; set; }
        public int BookId { get; set; }
        public Author author { get; set; }
        public int AuthorId { get; set; }

        
    }
}
