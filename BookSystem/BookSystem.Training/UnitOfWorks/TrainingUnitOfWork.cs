using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSystem.Data;
using BookSystem.Training.Contexts;
using BookSystem.Training.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookSystem.Training.UnitOfWorks
{
  public  class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public TrainingUnitOfWork(ITrainingDbContext context,  IBookRepository books,
            IAuthorRepository authors) :  base((DbContext)context)
            
        {
            Books = books;
            Authors = authors;
        }

       
    }
}
