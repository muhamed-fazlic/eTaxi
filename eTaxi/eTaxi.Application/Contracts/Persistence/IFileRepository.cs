using eTaxi.Application.DTOs.File;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IFileRepository : IGenericRepository<Domain.File, FileSearchDto>
    {
    }
}
