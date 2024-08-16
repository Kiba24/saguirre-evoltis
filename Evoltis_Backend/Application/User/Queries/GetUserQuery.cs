using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.User.Dto;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.User.Queries
{
    [Authorize("get-user")]
    public class GetUserQuery : IRequest<ResponseObjectJsonDto>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResponseObjectJsonDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObjectJsonDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
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

            var userDto = _mapper.Map<UserGetMeDto>(user);
            return new ResponseObjectJsonDto()
            {
                Message = "user found",
                Response = userDto,
                StatusCode = (int)CodeHttp.OK
            };
        }
    }

}
