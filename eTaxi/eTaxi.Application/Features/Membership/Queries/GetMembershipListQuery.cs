using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Membership;
using eTaxi.Application.DTOs.Rating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Membership.Queries
{
  
    public class GetMembershipListQuery : IRequest<List<MembershipDto>>
    {
        public MembershipSearchDto Search { get; set; }
    }

    public class GetMembershipListQueryHandler : IRequestHandler<GetMembershipListQuery, List<MembershipDto>>
    {
        private readonly IMembershipRepository _context;
        private readonly IMapper _mapper;
        public GetMembershipListQueryHandler(IMembershipRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MembershipDto>> Handle(GetMembershipListQuery request, CancellationToken cancellationToken)
        {
            var List = await _context.GetAsync(request.Search);
            return _mapper.Map<List<MembershipDto>>(List);
        }
    }
}
