using System.Diagnostics;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ZXH.ZentaoNotify.Core;
using ZXH.ZentaoNotify.Core.Configuration;
using ZXH.ZentaoNotify.Core.Web;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
{
    public class ZentaoNotifyDbContextFactory : IDesignTimeDbContextFactory<ZentaoNotifyDbContext>
    {
        public ZentaoNotifyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZentaoNotifyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
            var connectString = configuration.GetConnectionString(ZentaoNotifyConstants.ConnectionStringName);
            ZentaoNotifyDbContextConfigure.Configure(builder, connectString);
            return new ZentaoNotifyDbContext(builder.Options);
        }
    }
}