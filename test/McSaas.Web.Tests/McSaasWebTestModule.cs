using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using McSaas.EntityFrameworkCore;
using McSaas.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace McSaas.Web.Tests
{
    [DependsOn(
        typeof(McSaasWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class McSaasWebTestModule : AbpModule
    {
        public McSaasWebTestModule(McSaasEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(McSaasWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(McSaasWebMvcModule).Assembly);
        }
    }
}