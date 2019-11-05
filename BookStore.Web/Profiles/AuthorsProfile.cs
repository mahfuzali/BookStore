using AutoMapper;
using BookStore.Core.Entities;
using BookStore.Web.Helpers;
using BookStore.Web.Models;

namespace BookStore.Web.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

            CreateMap<AuthorForCreationDto, Author>();
        }
    }
}