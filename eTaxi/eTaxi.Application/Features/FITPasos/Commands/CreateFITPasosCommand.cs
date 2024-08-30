using AutoMapper;
using eTaxi.Application.Contracts.Message;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.FITPasos;
using eTaxi.Application.DTOs.Order;
using eTaxi.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.FITPasos.Commands
{
    public class CreateFITPasosCommand: IRequest<FITPasosDto>
    {
        public DateTime DatumIzdavanja { get; set; }
        public DateTime DatumVazenja { get; set; }
        public bool IsValid { get; set; }
        public int UserId { get; set; }


    }

    public class CrateFITPasosCommandHandler : IRequestHandler<CreateFITPasosCommand, FITPasosDto>
    {
        private readonly IFITPassosRepository _fitPasosRepository;
        private readonly IMapper _mapper;

        public CrateFITPasosCommandHandler(IFITPassosRepository fitPasosRepository, IMapper mapper)
        {
            _fitPasosRepository = fitPasosRepository;
            _mapper = mapper;
        }

        public async Task<FITPasosDto> Handle(CreateFITPasosCommand request,  CancellationToken cancellationToken)
        {

            var pasosToCreate = _mapper.Map<Domain.FITPasos>(request);

            await _fitPasosRepository.CreateAsync(pasosToCreate);

            var pasosDto = _mapper.Map<FITPasosDto>(pasosToCreate);
            return pasosDto;
        }
    }
}
