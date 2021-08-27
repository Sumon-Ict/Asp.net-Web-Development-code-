using AutoMapper;
using BookSystem.Areas.Admin.Models;
using BookSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSystem.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<EditAuthorModel, Author>().ReverseMap();



        }
    }
}
