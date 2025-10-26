using AutoMapper;
using BusinessLayer.Dtos;
using DataAccessLayer.Entities;

namespace BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<CreateAuthorDto, Author>();
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
