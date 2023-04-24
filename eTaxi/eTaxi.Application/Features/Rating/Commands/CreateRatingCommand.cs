using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Rating.Commands
{
    public class CreateRatingCommand: IRequest<int>
    {
        public int UserId { get; set; }
        public int UserDriverId { get; set; }
        public int OrderId { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; } = string.Empty;
    }

    public class CreateRatingCommandHandler: IRequestHandler<CreateRatingCommand, int>
    {
        private readonly IRatingRepository _context;
        private readonly IMapper _mapper;
        public CreateRatingCommandHandler(IRatingRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Rating>(request);
          await _context.CreateAsync(entity);
            return entity.Id;
        }
    }
}
