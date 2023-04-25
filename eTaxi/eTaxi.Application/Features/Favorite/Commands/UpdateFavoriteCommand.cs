using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Favorite.Commands
{
    public class UpdateFavoriteCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }

    public class UpdateFavoriteCommandHandler : IRequestHandler<UpdateFavoriteCommand, Unit>
    {
        private readonly IFavoriteRepository _context;
        private readonly IMapper _mapper;

        public UpdateFavoriteCommandHandler(IFavoriteRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var favoriteToUpdate = await _context.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.Favorite), request.Id);
            _mapper.Map(request, favoriteToUpdate);

            await _context.UpdateAsync(favoriteToUpdate);
            return Unit.Value;
        }
    }
}
