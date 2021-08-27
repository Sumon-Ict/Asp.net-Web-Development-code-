using Autofac;
using AutoMapper;
using BookSystem.Training.BusinessObjects;
using BookSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Areas.Admin.Models
{
    public class EditBookModel

    {
        public int Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = " Book title must be less than 200 character")]
        public string Title { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Barcode must be less than 200 character")]
        public string Barcode { get; set; }

        public double Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public EditBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public EditBookModel(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public void LoadModelData(int id)
        {
            var book = _bookService.GetBook(id);

            _mapper.Map(book, this);
        }

        public void updateBook()
        {
            var book = _mapper.Map<Book>(this);

            _bookService.UpdateBook(book);


        }

    }
}
