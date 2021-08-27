using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSystem.Data;
using BookSystem.Training.Repositories;

namespace BookSystem.Training.UnitOfWorks
{
    public interface ITrainingUnitOfWork  : IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
     
        

    }
}
