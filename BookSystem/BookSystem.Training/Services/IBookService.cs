using BookSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Training.Services
{
  public  interface IBookService
    {
        void CreateBook(Book book);

        Book GetBook(int id);
        void DeleteBook(int id);

        void UpdateBook(Book book);

        (IList<Book> records, int total, int totalDisplay) GetBooks(
            int pageIndex, int pageSize, string searchText, string sortText);





    }
}
