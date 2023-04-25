using MediatR;

namespace eTaxi.Application.Features.File.Commands
{
    public class UpdateFileCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
