using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace McSaas.Web.Views
{
    public abstract class McSaasRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected McSaasRazorPage()
        {
            LocalizationSourceName = McSaasConsts.LocalizationSourceName;
        }
    }
}
