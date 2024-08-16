using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.User.Dto;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Net;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommand : UserCreateDto, IRequest<ResponseObjectJsonDto> { }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseObjectJsonDto>
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            IUserRepository userRepository,

            IMapper mapper)
        {
            _userRepository = userRepository;;
            _mapper = mapper;
        }

        public async Task<ResponseObjectJsonDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var UserExists = await _userRepository.GetByEmailAsync(request.Email);

            if (UserExists is not null)
            {
                return new ResponseObjectJsonDto()
                {
                    Message = "Email already exists",
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            var newUser = await SaveUserInDB(request);

            return new ResponseObjectJsonDto
            {
                Message = "User created successfully",
                Response = true,
                StatusCode = (int)CodeHttp.OK
            };
        }

        private async Task<UserEntity> SaveUserInDB(CreateUserCommand request)
        {
            var newUser = _mapper.Map<UserEntity>(request);

            return await _userRepository.AddAsync(newUser);
        }
    }
}
