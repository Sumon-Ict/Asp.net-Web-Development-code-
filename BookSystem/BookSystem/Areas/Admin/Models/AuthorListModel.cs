using Autofac;
using BookSystem.Models;
using BookSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Areas.Admin.Models
{
    public class AuthorListModel
    {
        private readonly IAuthorService _authorService;
        public AuthorListModel()
        {
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();


        }
        public AuthorListModel(IAuthorService authorService)
        {
            _authorService = authorService;

        }

        internal Object getAuthors(DataTablesAjaxRequestModel tablemodel)
        {
            var data = _authorService.GetAuthors(
                tablemodel.PageIndex,
                tablemodel.PageSize,
                tablemodel.SearchText,
                tablemodel.GetSortText(new string[] { "Name", "DateOfBirth" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,                    
                            record.DateOfBirth.ToString(),
                           record.Id.ToString()
                        }
                  ).ToArray()
            };
        }

        public void deleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);

        }

    }
}
