using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO= BookSystem.Training.BusinessObjects;
using EO= BookSystem.Training.Entities;

namespace BookSystem.Training.Profiles
{
   public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<BO.Author, EO.Author>().ReverseMap();

        }

    }
}
