using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZXH.ZendaoNotify.Core.Authorization.Roles;
using ZXH.ZendaoNotify.Core.Authorization.Users;
using ZXH.ZendaoNotify.Core.MultiTenancy;

namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore
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