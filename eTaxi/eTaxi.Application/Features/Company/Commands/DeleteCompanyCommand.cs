using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Company.Commands
{
    public record DeleteCompanyCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _companyRepository.GetByIdAsync(request.Id);
            if (companyToDelete == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }
            await _companyRepository.DeleteAsync(companyToDelete);
            return Unit.Value;
        }
    }
}
