using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using McSaas.Configuration;
using Abp.Application.Navigation;
//using Volo.Abp.MultiTenancy;

namespace McSaas.Web.Startup
{
    [DependsOn(typeof(McSaasWebCoreModule))]
    //[DependsOn(typeof(AbpMultiTenancyModule))]

    public class McSaasWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public McSaasWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //配置导航和菜单
            Configuration.Navigation.Providers.Add<McSaasNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(McSaasWebMvcModule).GetAssembly());
        }
    }
}
