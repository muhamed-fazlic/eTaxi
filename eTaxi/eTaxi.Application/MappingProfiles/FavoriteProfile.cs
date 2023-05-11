using AutoMapper;
using eTaxi.Application.DTOs.Favorite;
using eTaxi.Application.Features.Favorite.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<FavoriteDto, Favorite>().ReverseMap();
            CreateMap<CreateFavoriteCommand, Favorite>().ReverseMap();
            CreateMap<UpdateFavoriteCommand, Favorite>().ReverseMap();
        }
    }
}
