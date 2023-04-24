using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Favorite;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Favorite.Queries
{
    public class GetFavoriteListQuery: IRequest<List<FavoriteDto>>
    {
        public int? UserId { get; set; }
    }

    public class GetFavoriteListQueryHandler : IRequestHandler<GetFavoriteListQuery, List<FavoriteDto>>
    {
        private readonly IFavoriteRepository _context;
        private readonly IMapper _mapper;
        public GetFavoriteListQueryHandler(IFavoriteRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<FavoriteDto>> Handle(GetFavoriteListQuery request, CancellationToken cancellationToken)
        {
            var favoriteList = await _context.GetAsync(request.UserId);
            var mappedFavorite = _mapper.Map<List<FavoriteDto>>(favoriteList);
            return mappedFavorite;
        }
    }
}
