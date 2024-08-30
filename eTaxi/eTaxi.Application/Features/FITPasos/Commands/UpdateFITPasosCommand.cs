using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Features.Order.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.FITPasos.Commands
{
    public class UpdateFITPasosCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime? DatumVazenja { get; set; }
        public bool isValid { get; set; }
    }

    public class UpdateFITPasosCommandHandler : IRequestHandler<UpdateFITPasosCommand, Unit>
    {
        private readonly IFITPassosRepository _fitPasosRepository;
        private readonly IMapper _mapper;
        public UpdateFITPasosCommandHandler(IFITPassosRepository fITPasosRepository, IMapper mapper)
        {
            _fitPasosRepository = fITPasosRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateFITPasosCommand request, CancellationToken cancellationToken)
        {
            var pasosToUpdate = await _fitPasosRepository.GetByIdAsync(request.Id);
            if (pasosToUpdate == null) throw new NotFoundException(nameof(Domain.FITPasos), request.Id);

            _mapper.Map(request, pasosToUpdate);
            await _fitPasosRepository.UpdateAsync(pasosToUpdate);
            return Unit.Value;
        }
    }
}
