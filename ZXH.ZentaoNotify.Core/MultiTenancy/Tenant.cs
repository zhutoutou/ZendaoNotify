using Abp.MultiTenancy;
using ZXH.ZendaoNotify.Core.Authorization.Users;

namespace ZXH.ZendaoNotify.Core.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
