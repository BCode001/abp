using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ChartTest.EntityFrameworkCore
{
    public class ChartTestMigrationsDbContextFactory : IDesignTimeDbContextFactory<ChartTestMigrationsDbContext>
    {
        public ChartTestMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ChartTestMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ChartTestMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
