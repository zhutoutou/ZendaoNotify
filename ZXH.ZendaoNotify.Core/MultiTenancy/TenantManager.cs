using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using ZXH.ZendaoNotify.Core.Authorization.Users;
using ZXH.ZendaoNotify.Core.Editions;

namespace ZXH.ZendaoNotify.Core.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
