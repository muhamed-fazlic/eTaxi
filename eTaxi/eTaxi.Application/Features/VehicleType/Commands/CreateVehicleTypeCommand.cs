using MediatR;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class CreateVehicleTypeCommand : IRequest<int>
    {

        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public string ImageUrl { get; set; }

    }
}
