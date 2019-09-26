using Abp.Authorization;
using Abp.Authorization.Roles;
using AutoMapper;
using ZXH.ZentaoNotify.Core.Authorization.Roles;

namespace ZXH.ZentaoNotify.Application.Roles.Dto
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            CreateMap<Permission, string>()
                .ConvertUsing(dest => dest.Name);
            CreateMap<RolePermissionSetting, string>()
                .ConvertUsing(dest => dest.Name);

            CreateMap<RoleDto, Role>()
                .ForMember(dest => dest.Permissions, opt => opt.Ignore());
        }
    }
}