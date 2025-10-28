using AutoMapper;
using BusinessLayer.Dtos;
using DataAccessEFLayer.Entities;

namespace BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            CreateMap<BookFilterDto, BookRepoFilter>().ReverseMap();
            CreateMap<AuthorFilterDto, AuthorRepoFilter>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<CreateAuthorDto, Author>().ForMember(dest => dest.Books, opt => opt.Ignore());
            CreateMap<UpdateAuthorDto, Author>().ForMember(dest => dest.Books, opt => opt.Ignore());

            CreateMap<Author, AuthorDto>().ForMember(dest => dest.BooksIds, opt => opt.MapFrom(src => src.Books.Select(b => b.Id)));
        }
    }
}
