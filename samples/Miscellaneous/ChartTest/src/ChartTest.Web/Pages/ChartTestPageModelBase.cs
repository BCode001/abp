using ChartTest.Localization.ChartTest;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ChartTest.Pages
{
    public abstract class ChartTestPageModelBase : AbpPageModel
    {
        protected ChartTestPageModelBase()
        {
            LocalizationResourceType = typeof(ChartTestResource);
        }
    }
}