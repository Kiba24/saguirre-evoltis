using Application.Common.Models;
using Application.Subscription.Commands;
using Application.User.Commands.CreateUser;
using Application.User.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<ResponseObjectJsonDto>> CreateSubscription([FromBody] CreateSubscriptionCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetAllSubscriptions([FromQuery] GetAllSubscriptionsQuery query)
        {
            var result = await Mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }
    }
}
