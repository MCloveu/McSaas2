using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using McSaas.Authorization;

namespace McSaas
{
    [DependsOn(
        typeof(McSaasCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class McSaasApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<McSaasAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(McSaasApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
