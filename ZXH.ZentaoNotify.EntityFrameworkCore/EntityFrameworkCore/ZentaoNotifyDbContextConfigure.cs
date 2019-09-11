using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
{

    public class ZentaoNotifyDbContextConfigure
    {
        public static void Configure(DbContextOptionsBuilder<ZentaoNotifyDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZentaoNotifyDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}