using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Favorite;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Favorite.Queries
{
    public record GetFavoriteQuery(int Id) : IRequest<FavoriteDto>
    {
    }

    public class GetFavoriteQueryHandler: IRequestHandler<GetFavoriteQuery, FavoriteDto>
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;
        public GetFavoriteQueryHandler(IFavoriteRepository favoriteRepository, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
        }
        public async Task<FavoriteDto> Handle(GetFavoriteQuery request, CancellationToken cancellationToken)
        {
            var favorite = await _favoriteRepository.GetByIdAsync(request.Id);
            if (favorite == null) throw new NotFoundException(nameof(Favorite), request.Id);
            return _mapper.Map<FavoriteDto>(request);
        }
    }
}
