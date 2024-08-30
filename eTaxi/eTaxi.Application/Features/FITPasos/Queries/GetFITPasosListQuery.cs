using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.FITPasos;
using MediatR;

namespace eTaxi.Application.Features.FITPasos.Queries
{
    public class GetFITPasosListQuery : IRequest<List<FITPasosDto>>
    {
        public FITPasosSearchDto Search { get; set; }
    }

    public class GetFITPasosListQueryHandler : IRequestHandler<GetFITPasosListQuery, List<FITPasosDto>>
    {
        private readonly IFITPassosRepository _fitPasosRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetFITPasosListQueryHandler(IFITPassosRepository fitPasosRepository, IMapper mapper,  IUserRepository userRepository)
        {
            _fitPasosRepository = fitPasosRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<FITPasosDto>> Handle(GetFITPasosListQuery request, CancellationToken cancellationToken)
        {
            var pasosList = await _fitPasosRepository.GetAsync(request.Search);

            foreach (var pasos in pasosList)
            {
               
                    var user = await _userRepository.GetByIdAsync((int)pasos.UserId);
                    pasos.User = user;
                
            }

            var pasosDtoList = _mapper.Map<List<FITPasosDto>>(pasosList);

     

            return pasosDtoList;
        }
    }
}
