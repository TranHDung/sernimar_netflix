using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using netflix.Authorization;

namespace netflix
{
    [DependsOn(
        typeof(netflixCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class netflixApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<netflixAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(netflixApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
