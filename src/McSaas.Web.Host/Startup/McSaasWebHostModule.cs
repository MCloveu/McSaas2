using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using McSaas.Configuration;

namespace McSaas.Web.Host.Startup
{
    [DependsOn(
       typeof(McSaasWebCoreModule))]
    public class McSaasWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public McSaasWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(McSaasWebHostModule).GetAssembly());
        }
    }
}
