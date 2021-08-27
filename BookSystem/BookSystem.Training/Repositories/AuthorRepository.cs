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
  public  class AuthorRepository : Repository<Author, int>,  IAuthorRepository 
    {
        public AuthorRepository(ITrainingDbContext  context)
            : base((DbContext)context)
        {

        }
    }
}
