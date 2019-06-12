using ChartTest.Localization.ChartTest;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ChartTest.Permissions
{
    public class ChartTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ChartTestPermissions.GroupName);

            //Define your own permissions here. Examaple:
            //myGroup.AddPermission(ChartTestPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ChartTestResource>(name);
        }
    }
}
