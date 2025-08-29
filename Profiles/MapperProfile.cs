using AutoMapper;
using PustokApp.Models;
using PustokApp.ViewModels;

namespace PustokApp.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookTestVm>()
               
                .ForMember(dest => dest.BookImageUrls, opt => opt.MapFrom(src => src.BookImages.Select(bt => bt.ImageUrl)))
                .ForMember(dest => dest.BookTagNames, opt => opt.MapFrom(src => src.BookTags.Select(bt => bt.Tag.Name)));
            CreateMap<Genre, GenreVm>();
              
        }       
    }
}
