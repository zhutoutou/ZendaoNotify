using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ZXH.ZentaoNotify.Application.Roles.Dto;
using ZXH.ZentaoNotify.Application.Users.Dto;
using ZXH.ZentaoNotify.Core.Authorization.Users;

namespace ZXH.ZentaoNotify.Application.Users
{
    public class UseAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        public UseAppService(IRepository<User, long> repository) : base(repository)
        {
        }

        public override Task<UserDto> Create(CreateUserDto input)
        {
            return base.Create(input);
        }

        public override Task<UserDto> Update(UserDto input)
        {
            return base.Update(input);
        }

        public override Task Delete(EntityDto<long> input)
        {
            return base.Delete(input);
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            return base.MapToEntity(createInput);
        }

        protected override void MapToEntity(UserDto updateInput, User entity)
        {
            base.MapToEntity(updateInput, entity);
        }

        protected override UserDto MapToEntityDto(User entity)
        {
            return base.MapToEntityDto(entity);
        }

        public Task<ListResultDto<RoleDto>> GetRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}