using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace McSaas.Controllers
{
    public abstract class McSaasControllerBase: AbpController
    {
        protected McSaasControllerBase()
        {
            LocalizationSourceName = McSaasConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
