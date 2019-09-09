using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ZXH.ZentaoNotify.EntityFrameworkCore.EntityFrameworkCore
{

    public class ZendaoNotifyDbContextConfigure
    {
        public static void Configure(DbContextOptionsBuilder<ZendaoNotifyDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZendaoNotifyDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }

        public static void ConfigureInMemory(DbContextOptionsBuilder<ZendaoNotifyDbContext> builder,
            string databaseName)
        {
            builder.UseInMemoryDatabase(databaseName);
        }
    }
}