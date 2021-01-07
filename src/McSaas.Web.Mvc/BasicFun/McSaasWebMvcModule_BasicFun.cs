using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using McSaas.Configuration;
using Abp.Application.Navigation;
namespace McSaas.Web.BasicFun
{
    [DependsOn(typeof(McSaasWebCoreModule))]
    public class McSaasWebMvcModule_BasicFun : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public McSaasWebMvcModule_BasicFun(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<McSaasNavigationProvider_BasicFun>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(McSaasWebMvcModule_BasicFun).GetAssembly());
        }
    }
}
