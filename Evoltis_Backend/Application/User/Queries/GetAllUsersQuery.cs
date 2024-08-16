using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.User.Dto;
using AutoMapper;
using MediatR;

namespace Application.User.Queries
{
    public class GetAllUsersQuery : IRequest<ResponseObjectJsonDto>
    {
    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ResponseObjectJsonDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObjectJsonDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            if (users is null)
            {
                return new ResponseObjectJsonDto()
                {
                    Message = "user not found",
                    StatusCode = (int)CodeHttp.NOTFOUND
                };                
            }

            var userDtos = _mapper.Map<List<UserGetMeDto>>(users);
            return new ResponseObjectJsonDto()
            {
                Message = "users found",
                Response = userDtos,
                StatusCode = (int)CodeHttp.OK
            };
        }
    }

}
