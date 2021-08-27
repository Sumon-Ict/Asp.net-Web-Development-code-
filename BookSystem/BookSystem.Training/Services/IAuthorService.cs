using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSystem.Training.BusinessObjects;

namespace BookSystem.Training.Services
{
   public  interface IAuthorService
    {
        void CreateAuthor(Author author);

        void DeleteAuthor(int id);
        Author GetAuthor(int id);

        void UpdateAuthor(Author author);

        (IList<Author>records,int total,int totalDisplay) GetAuthors(
             int pageIndex, int pageSize, string searchText, string sortText);




    }
}
