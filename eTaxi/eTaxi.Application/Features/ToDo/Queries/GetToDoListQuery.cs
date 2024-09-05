using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.ToDo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.ToDo.Queries
{
 
    public class GetToDoListQuery : IRequest<List<TodoDto>>
    {
        public ToDoSearchDto Search { get; set; }
    }

    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, List<TodoDto>>
    {
        private readonly IToDoRepository _context;
        private readonly IMapper _mapper;
        public GetToDoListQueryHandler(IToDoRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TodoDto>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var ratingList = await _context.GetAsync(request.Search);
            return _mapper.Map<List<TodoDto>>(ratingList);
        }
    }
}
