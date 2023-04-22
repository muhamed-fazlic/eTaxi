using eTaxi.Application.DTOs.VehicleType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class GetVehicleTypeQuery : IRequest<VehicleTypeDto>
    {
        public int Id { get; }

        public GetVehicleTypeQuery(int id)
        {
            Id = id;
        }
    }
    public class GetVehicleTypeList : IRequest<List<VehicleTypeDto>>
    {
        public string Search { get; set; }
    }

}
