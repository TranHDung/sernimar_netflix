using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using netflix.EntityFrameworkCore;
using netflix.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace netflix.Web.Tests
{
    [DependsOn(
        typeof(netflixWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class netflixWebTestModule : AbpModule
    {
        public netflixWebTestModule(netflixEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(netflixWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(netflixWebMvcModule).Assembly);
        }
    }
}