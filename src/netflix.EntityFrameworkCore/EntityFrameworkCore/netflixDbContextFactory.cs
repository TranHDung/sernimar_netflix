using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using netflix.Configuration;
using netflix.Web;

namespace netflix.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class netflixDbContextFactory : IDesignTimeDbContextFactory<netflixDbContext>
    {
        public netflixDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<netflixDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            netflixDbContextConfigurer.Configure(builder, configuration.GetConnectionString(netflixConsts.ConnectionStringName));

            return new netflixDbContext(builder.Options);
        }
    }
}
