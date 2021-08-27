using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSystem.Data;
using BookSystem.Training.Entities;

namespace BookSystem.Training.Repositories
{
    public interface  IAuthorRepository : IRepository<Author,int>
    {

    }
}
