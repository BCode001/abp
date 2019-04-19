using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Volo.Abp.FluentValidation.AspNetCore
{
    [DependsOn(
        typeof(AbpFluentValidationModule)
    )]
    public class AbpFluentValidationAspNetCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<MvcOptions>(options =>
            {
                options.ModelValidatorProviders.Insert(0, new FluentValidationModelValidatorProvider(context.Services.BuildServiceProvider()));
            });
        }
    }
}
