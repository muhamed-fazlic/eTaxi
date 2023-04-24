using AutoMapper;
using eTaxi.Application.DTOs.Favorite;
using eTaxi.Application.Features.Favorite.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class FavoriteProfile: Profile
    {
        public FavoriteProfile()
        {
            CreateMap<FavoriteDto, FavoriteProfile>().ReverseMap();
            CreateMap<CreateFavoriteCommand, FavoriteProfile>().ReverseMap();
            CreateMap<UpdateFavoriteCommand, FavoriteProfile>().ReverseMap();
        }
    }
}
