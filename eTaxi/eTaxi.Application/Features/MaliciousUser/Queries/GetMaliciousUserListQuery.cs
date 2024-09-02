using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.MaliciousUser;
using eTaxi.Application.DTOs.Rating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.MaliciousUser.Queries
{
   
    public class GetMaliciousUserListQuery : IRequest<List<MaliciousUserDto>>
    {
        public MaliciousUserSearchDto Search { get; set; }
    }

    public class GetMaliciousUserListQueryHandler : IRequestHandler<GetMaliciousUserListQuery, List<MaliciousUserDto>>
    {
        private readonly IMaliciousUserRepository _context;
        private readonly IMapper _mapper;
        public GetMaliciousUserListQueryHandler(IMaliciousUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MaliciousUserDto>> Handle(GetMaliciousUserListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.GetAsync(request.Search);
            return _mapper.Map<List<MaliciousUserDto>>(list);
        }
    }
}
