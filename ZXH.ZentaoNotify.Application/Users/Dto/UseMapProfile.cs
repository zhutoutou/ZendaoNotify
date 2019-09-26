using AutoMapper;
using ZXH.ZentaoNotify.Core.Authorization.Users;

namespace ZXH.ZentaoNotify.Application.Users.Dto
{
    public class UseMapProfile : Profile
    {
        public UseMapProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}   