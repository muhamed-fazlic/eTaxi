using AutoMapper;
using eTaxi.Application.DTOs.Favorite;
using eTaxi.Application.Features.Favorite.Commands;

namespace eTaxi.Application.MappingProfiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<FavoriteDto, FavoriteProfile>().ReverseMap();
            CreateMap<CreateFavoriteCommand, FavoriteProfile>().ReverseMap();
            CreateMap<UpdateFavoriteCommand, FavoriteProfile>().ReverseMap();
        }
    }
}
