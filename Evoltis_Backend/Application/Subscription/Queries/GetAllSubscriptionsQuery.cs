using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.Subscription.Dto;
using Application.User.Dto;
using AutoMapper;
using MediatR;

namespace Application.User.Queries
{
    public class GetAllSubscriptionsQuery : IRequest<ResponseObjectJsonDto>
    {
    }

    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, ResponseObjectJsonDto>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public GetAllSubscriptionsQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObjectJsonDto> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();

            if (subscriptions is null)
            {
                return new ResponseObjectJsonDto()
                {
                    Message = "subscriptions not found",
                    StatusCode = (int)CodeHttp.NOTFOUND
                };
            }

            var subscriptionsDto = _mapper.Map<List<GetSubscriptionDto>>(subscriptions);
            return new ResponseObjectJsonDto()
            {
                Message = "subscriptions found",
                Response = subscriptionsDto,
                StatusCode = (int)CodeHttp.OK
            };
        }
    }

}
