using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using McSaas.Configuration;
using McSaas.Web;

namespace McSaas.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class McSaasDbContextFactory : IDesignTimeDbContextFactory<McSaasDbContext>
    {
        public McSaasDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<McSaasDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            McSaasDbContextConfigurer.Configure(builder, configuration.GetConnectionString(McSaasConsts.ConnectionStringName));

            return new McSaasDbContext(builder.Options);
        }
    }
}
