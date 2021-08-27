using AutoMapper;
using BookSystem.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = BookSystem.Training.BusinessObjects;


namespace BookSystem.Training.Profiles
{
   public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookModel, BO.Book>().ReverseMap();
            CreateMap<EditBookModel, BO.Book>().ReverseMap();



        }
    }
}
