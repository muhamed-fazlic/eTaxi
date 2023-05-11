using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Company.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToCreate = _mapper.Map<Domain.Company>(request);
            await _companyRepository.CreateAsync(companyToCreate);
            return companyToCreate.Id;
        }
    }

}
