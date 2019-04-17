using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using VoloBlog.EntityFrameworkCore;

namespace VoloBlog.Migrator
{
    [DependsOn(typeof(VoloBlogEntityFrameworkCoreModule))]
    public class VoloBlogMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAbpDbContext<VoloBlogDbContext>();

            Configure<DbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = configuration["ConnectionString"];
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }
    }
}