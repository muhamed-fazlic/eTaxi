using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using eTaxi.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.FITPasos.Commands
{
    public record DeleteFitPasosCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteFitPasosCommandHandler : IRequestHandler<DeleteFitPasosCommand, Unit>
    {
        private readonly IFITPassosRepository _fitPasosRepository;
        private readonly IMapper _mapper;
        public DeleteFitPasosCommandHandler(IFITPassosRepository fitPasosRepository, IMapper mapper)
        {
            _fitPasosRepository = fitPasosRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteFitPasosCommand request, CancellationToken cancellationToken)
        {
            var pasos = await _fitPasosRepository.GetByIdAsync(request.Id);
            if (pasos == null)
            {
                throw new NotFoundException(nameof(FITPasos), request.Id);
            }
            await _fitPasosRepository.DeleteAsync(pasos);
            return Unit.Value;
        }
    }
}
