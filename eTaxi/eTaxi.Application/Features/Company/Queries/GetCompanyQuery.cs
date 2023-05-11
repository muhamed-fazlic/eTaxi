using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Company;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Company.Queries
{
    public record GetCompanyQuery(int Id) : IRequest<CompanyDto>
    {
    }

    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
