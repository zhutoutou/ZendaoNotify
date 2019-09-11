using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZXH.ZentaoNotify.Core.Authorization.Roles;
using ZXH.ZentaoNotify.Core.Authorization.Users;
using ZXH.ZentaoNotify.Core.MultiTenancy;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
{
    public class ZentaoNotifyDbContext : AbpZeroDbContext<Tenant, Role, User, ZentaoNotifyDbContext>
    {

        public ZentaoNotifyDbContext(DbContextOptions<ZentaoNotifyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}