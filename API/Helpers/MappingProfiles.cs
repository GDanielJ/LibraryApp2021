using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookToReturnDto>()
                .ForMember(d => d.AuthorFirstname, o => o.MapFrom(s => s.Author.Firstname))
                .ForMember(d => d.AuthorLastname, o => o.MapFrom(s => s.Author.Lastname));
        }
    }
}
