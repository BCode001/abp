using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace VoloBlog.Migrator
{
    public static class AppExtensions
    {
        public static T Resolve<T>(this IAbpApplicationWithInternalServiceProvider app)
        {
            return (T)app.ServiceProvider.GetRequiredService<T>();
        }
    }
}