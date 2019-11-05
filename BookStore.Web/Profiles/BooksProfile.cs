using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Web.Models;

namespace BookStore.Web.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreationDto, Book>();
        }
    }
}