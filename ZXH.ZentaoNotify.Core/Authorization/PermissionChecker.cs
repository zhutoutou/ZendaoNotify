using Abp.Authorization;
using ZXH.ZendaoNotify.Core.Authorization.Roles;
using ZXH.ZendaoNotify.Core.Authorization.Users;

namespace ZXH.ZendaoNotify.Core.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
