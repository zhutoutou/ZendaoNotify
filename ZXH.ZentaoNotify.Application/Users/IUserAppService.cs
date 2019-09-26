using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ZXH.ZentaoNotify.Application.Roles.Dto;
using ZXH.ZentaoNotify.Application.Users.Dto;

namespace ZXH.ZentaoNotify.Application.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}