using Volo.Abp;

namespace ChartTest
{
    public abstract class ChartTestApplicationTestBase : AbpIntegratedTest<ChartTestApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
