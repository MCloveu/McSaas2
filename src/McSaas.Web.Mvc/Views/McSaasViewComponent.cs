using Abp.AspNetCore.Mvc.ViewComponents;

namespace McSaas.Web.Views
{
    public abstract class McSaasViewComponent : AbpViewComponent
    {
        protected McSaasViewComponent()
        {
            LocalizationSourceName = McSaasConsts.LocalizationSourceName;
        }
    }
}
