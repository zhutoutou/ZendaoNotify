using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZXH.ZentaoNotify.Core.Authorization.Roles;
using ZXH.ZentaoNotify.Core.Authorization.Users;
using ZXH.ZentaoNotify.Core.MultiTenancy;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
{
    public class ZendaoNotifyDbContext : AbpZeroDbContext<Tenant, Role, User, ZendaoNotifyDbContext>
    {

        public ZendaoNotifyDbContext(DbContextOptions<ZendaoNotifyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}