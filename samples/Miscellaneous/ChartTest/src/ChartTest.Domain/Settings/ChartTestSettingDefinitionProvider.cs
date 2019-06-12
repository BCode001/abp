using Volo.Abp.Settings;

namespace ChartTest.Settings
{
    public class ChartTestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ChartTestSettings.MySetting1));
        }
    }
}
