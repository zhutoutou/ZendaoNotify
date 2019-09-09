using Abp.Extensions;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZXH.ZendaoNotify.Core;
using ZXH.ZendaoNotify.Core.Configuration;
using ZXH.ZendaoNotify.Core.Web;

namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore
{
    public class ZendaoNotifyDbContextFactory : IDesignTimeDbContextFactory<ZendaoNotifyDbContext>
    {
        public ZendaoNotifyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZendaoNotifyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            var connectString = configuration.GetConnectionString(ZendaoNotifyConstants.ConnectionStringName);
            if (connectString.IsNullOrWhiteSpace())
            {
                ZendaoNotifyDbContextConfigure.ConfigureInMemory(builder, ZendaoNotifyConstants.MemoryDatabaseDefaultName);
            }
            else
            {
                ZendaoNotifyDbContextConfigure.Configure(builder, connectString);

            }
            return new ZendaoNotifyDbContext(builder.Options);
        }
    }
}