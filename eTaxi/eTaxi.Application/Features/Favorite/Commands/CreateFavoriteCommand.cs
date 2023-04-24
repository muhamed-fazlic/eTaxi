using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Favorite.Commands
{
    public class CreateFavoriteCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }

    public class CreateFavoriteCommandHandler: IRequestHandler<CreateFavoriteCommand, int>
    {
        private readonly IFavoriteRepository _context;
        private readonly IMapper _mapper;

        public CreateFavoriteCommandHandler(IFavoriteRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favoriteToCreate = _mapper.Map<Domain.Favorite>(request);
            await _context.CreateAsync(favoriteToCreate);
            return favoriteToCreate.Id;
        }
    }
}
