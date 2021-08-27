using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSystem.Data;
using BookSystem.Training.Contexts;
using BookSystem.Training.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Training.Repositories
{
   public  class BookRepository : Repository<Book,  int>,  IBookRepository
    {
        public BookRepository(ITrainingDbContext context)
            : base((DbContext)context)
        {

        }
       
       
    }
}
