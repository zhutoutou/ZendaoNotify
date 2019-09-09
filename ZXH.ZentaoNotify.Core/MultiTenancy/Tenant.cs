using Abp.MultiTenancy;
using ZXH.ZentaoNotify.Core.Authorization.Users;

namespace ZXH.ZentaoNotify.Core.MultiTenancy
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
