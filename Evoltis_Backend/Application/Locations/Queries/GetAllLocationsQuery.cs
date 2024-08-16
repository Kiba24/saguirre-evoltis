using Application.Common.Interfaces.Services;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Locations.Queries
{
    [Authorize("get-locations")]
    public class GetAllLocationsQuery : IRequest<ResponseObjectJsonDto>
    {


    }
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, ResponseObjectJsonDto>
    {
        private readonly ILocationService _locationService;
        public GetAllLocationsQueryHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<ResponseObjectJsonDto> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var response = await _locationService.GetProvinces();

            if (response == null) {
                return new ResponseObjectJsonDto()
                {
                    Message = "No file found",
                    Response = null,
                    StatusCode = 404
                };
            }

            return new ResponseObjectJsonDto()
            {
                Message = "Locations found",
                Response = response,
                StatusCode = 200
            };
        }
    }
}
