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
    public class CreateAuthorModel
    {
        [Required,MaxLength(200,ErrorMessage ="Author name must be less than 200 character")]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        private readonly IAuthorService _authorService;

        private readonly IMapper _mapper;


        public CreateAuthorModel()
        {
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public CreateAuthorModel(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public void createAuthor()
        {
            var author = _mapper.Map<Author>(this);
            _authorService.CreateAuthor(author);
        }


    }
}
