using Application.Common.Models;
using Application.Common.Models.Locations;
using Application.Locations.Dto;
using Application.Subscription.Dto;
using Application.User.Commands.CreateUser;
using Application.User.Dto;
using AutoMapper;
using Domain.Entities;



namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, CreateUserCommand>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();
            CreateMap<UserEntity, UserGetMeDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();
            CreateMap<UserEntity, UserCreateDto>().ReverseMap();

            CreateMap<LocationModel, LocationDto>().ReverseMap();

            CreateMap<CreateSubscriptionDto, SubscriptionEntity>().ReverseMap();
            CreateMap<GetSubscriptionDto, SubscriptionEntity>().ReverseMap();

        }
    }
}
