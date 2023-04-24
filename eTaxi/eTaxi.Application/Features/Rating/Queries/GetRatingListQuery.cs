using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Rating;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Rating.Queries
{
    public class GetRatingListQuery: IRequest<List<RatingDto>>
    {
        public RatingSearchDto Search { get; set; }
    }

    public class GetRatingListQueryHandler: IRequestHandler<GetRatingListQuery, List<RatingDto>>
    {
        private readonly IRatingRepository _context;
        private readonly IMapper _mapper;
        public GetRatingListQueryHandler(IRatingRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RatingDto>> Handle(GetRatingListQuery request, CancellationToken cancellationToken)
        {
            var ratingList = await _context.GetAsync(request.Search);
            return _mapper.Map<List<RatingDto>>(ratingList);
        }
    }
}
