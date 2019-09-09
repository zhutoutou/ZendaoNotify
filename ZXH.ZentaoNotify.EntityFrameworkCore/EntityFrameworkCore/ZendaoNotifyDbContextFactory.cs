using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.Core.Configuration;
using ZXH.ZentaoNotify.Core.Web;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
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