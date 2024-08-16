using Application.Common.Models;
using Application.Locations.Queries;

using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetProvinces([FromQuery] GetAllLocationsQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("province/{id}")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetCities([FromQuery] GetCitiesByProvinceQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
