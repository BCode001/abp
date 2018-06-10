﻿namespace Volo.Abp.AspNetCore.Mvc.UI.Bundling.Libraries.Bootstrap
{
    public class BootstrapStyleBundleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/libs/bootstrap/css/bootstrap.css");
        }
    }
}