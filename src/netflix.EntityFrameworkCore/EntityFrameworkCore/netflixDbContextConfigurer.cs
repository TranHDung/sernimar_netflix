using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace netflix.EntityFrameworkCore
{
    public static class netflixDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<netflixDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<netflixDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
