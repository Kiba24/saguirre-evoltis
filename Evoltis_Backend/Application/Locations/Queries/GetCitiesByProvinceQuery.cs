using Application.Common.Interfaces.Services;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Locations.Queries
{
    [Authorize("get-province")]
    public class GetCitiesByProvinceQuery : IRequest<ResponseObjectJsonDto>
    {
        [FromRoute(Name = "id")]
        public int Id {  get; set; }
    }

    public class GetCitiesByProvinceQueryHandler : IRequestHandler<GetCitiesByProvinceQuery, ResponseObjectJsonDto>
    {
        private readonly ILocationService _locationService;

        public GetCitiesByProvinceQueryHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<ResponseObjectJsonDto> Handle(GetCitiesByProvinceQuery request, CancellationToken cancellationToken)
        {
            var cities = await _locationService.GetCities(request.Id);

            if (cities == null)
            {
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
                Response = cities,
                StatusCode = 200
            };
        }
        
    }

}
