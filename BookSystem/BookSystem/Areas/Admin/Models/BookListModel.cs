using Autofac;
using BookSystem.Models;
using BookSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Areas.Admin.Models
{
    public class BookListModel
    {
        private readonly IBookService _bookService;
        public BookListModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();


        }
        public BookListModel(IBookService bookService)
        {
            _bookService = bookService;

        }

        internal Object getBooks(DataTablesAjaxRequestModel tablemodel)
        {
            var data = _bookService.GetBooks(
                tablemodel.PageIndex,
                tablemodel.PageSize,
                tablemodel.SearchText,
                tablemodel.GetSortText(new string[] { "Title", "Barcode", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Title,
                            record.Barcode,
                            record.Price.ToString(),
                           record.Id.ToString()
                        }
                  ).ToArray()
            };
        }

        public void deleteBook(int id)
        {
            _bookService.DeleteBook(id);

        }


    }
}
