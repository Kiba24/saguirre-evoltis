using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.User.Dto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : UserUpdateDto, IRequest<ResponseObjectJsonDto> 
    {
        public int Id { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseObjectJsonDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObjectJsonDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return new ResponseObjectJsonDto()
                {
                    Message = "user not found",
                    StatusCode = (int)CodeHttp.NOTFOUND
                };
            }

            _mapper.Map(request, user);

            var result = await _userRepository.UpdateAsync(request.Id, user);

            return new ResponseObjectJsonDto()
            {
                Message = $"user {result.Id} update",
                Response = true,
                StatusCode = (int)CodeHttp.OK
            };
        }
    }
}
