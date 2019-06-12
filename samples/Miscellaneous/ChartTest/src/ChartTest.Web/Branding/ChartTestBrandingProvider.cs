using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace ChartTest.Branding
{
    [Dependency(ReplaceServices = true)]
    public class ChartTestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ChartTest";
    }
}
