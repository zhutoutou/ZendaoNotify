using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZXH.ZendaoNotify.Core;
using ZXH.ZendaoNotify.Core.Configuration;
using ZXH.ZendaoNotify.Core.Web;

namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore{
    public class ZendaoNotifyDbContextFactory : IDesignTimeDbContextFactory<ZendaoNotifyDbContext>
    {
        public ZendaoNotifyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZendaoNotifyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ZendaoNotifyDbContextConfigure.Configure(builder,configuration.GetConnectionString(ZendaoNotifyConstants.ConnectionStringName));

            return new ZendaoNotifyDbContext(builder.Options);
        }
    }
}