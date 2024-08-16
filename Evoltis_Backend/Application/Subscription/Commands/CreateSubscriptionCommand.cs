using Amazon.Runtime.Internal;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Subscription.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Subscription.Commands
{
    public class CreateSubscriptionCommand : IRequest<ResponseObjectJsonDto>
    {
        public CreateSubscriptionDto CreateSubscriptionDto { get; set; }
    }

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ResponseObjectJsonDto>
    {

        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository,
            IMapper mapper) {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<ResponseObjectJsonDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var implicatedUser = await _userRepository.GetByIdAsync(request.CreateSubscriptionDto.UserId);

            if (implicatedUser is null)
            {
                return new ResponseObjectJsonDto()
                {
                    Message = "User not found",
                    Response = null,
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }

            var newSubscription = _mapper.Map<SubscriptionEntity>(request.CreateSubscriptionDto);
            
            var savedEntity = await _subscriptionRepository.AddAsync(newSubscription);

            return new ResponseObjectJsonDto()
            {
                Message = "Subscription created successfully",
                Response = newSubscription ,
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
