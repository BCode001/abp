using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using ChartTest.Localization.ChartTest;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ChartTest.Pages
{
    public abstract class ChartTestPageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<ChartTestResource> L { get; set; }
    }
}
