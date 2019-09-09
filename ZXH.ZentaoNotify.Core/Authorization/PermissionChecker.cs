using Abp.Authorization;
using ZXH.ZentaoNotify.Core.Authorization.Roles;
using ZXH.ZentaoNotify.Core.Authorization.Users;

namespace ZXH.ZentaoNotify.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
