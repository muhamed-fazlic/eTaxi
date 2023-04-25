using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Rating.Commands
{
    public class UpdateRatingCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; } = string.Empty;
    }

    public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, Unit>
    {
        private readonly IRatingRepository _context;
        private readonly IMapper _mapper;
        public UpdateRatingCommandHandler(IRatingRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }
            _mapper.Map(request, entity);
            await _context.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
