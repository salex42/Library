using AutoMapper;
using Library.Models.Dto;
using Library.Models.Library;

namespace Library
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<Reader, ReaderDto>();
            CreateMap<ReaderDto, Reader>();
        }
    }
}

