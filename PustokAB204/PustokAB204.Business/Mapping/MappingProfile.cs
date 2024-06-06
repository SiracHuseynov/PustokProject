using AutoMapper;
using PustokAB204.Business.DTOs.AuthorDTOs;
using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Core.Models;

namespace PustokAB204.Business.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookCreateDTO, Book>().ReverseMap();
        CreateMap<Book, BookGetDTO>().ReverseMap();
        CreateMap<AuthorCreateDTO, Author>().ReverseMap(); 
        CreateMap<Author, AuthorGetDTO>().ReverseMap();
    }
}
