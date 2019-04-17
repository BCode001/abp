using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VoloBlog.EntityFrameworkCore
{
    public class VoloBlogDbContextFactory : IDesignTimeDbContextFactory<VoloBlogDbContext>
    {
        public VoloBlogDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<VoloBlogDbContext>()
                .UseSqlServer(configuration.GetConnectionString("SqlServer"));

            return new VoloBlogDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VoloBlog/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
