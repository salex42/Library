using AutoMapper;
using Library.Models.Dto;
using Library.Models.Library;

namespace Library
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
        }
    }
}

