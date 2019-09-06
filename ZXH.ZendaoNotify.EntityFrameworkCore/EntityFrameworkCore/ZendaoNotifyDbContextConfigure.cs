using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemoryDbContextOptionsExtensions;

namespace ZXH.ZendaoNotify.EntityFrameworkCore.EntityFrameworkCore
{

    public class ZendaoNotifyDbContextConfigure
    {
        public static void Configure(DbContextOptionsBuilder<ZendaoNotifyDbContext> builder, string connectionString)
        {
            Microsoft.EntityFrameworkCore.InMemoryDbContextOptionsExtensions.
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZendaoNotifyDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}