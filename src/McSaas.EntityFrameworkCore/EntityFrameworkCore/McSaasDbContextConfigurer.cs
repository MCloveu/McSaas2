using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace McSaas.EntityFrameworkCore
{
    public static class McSaasDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<McSaasDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<McSaasDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
