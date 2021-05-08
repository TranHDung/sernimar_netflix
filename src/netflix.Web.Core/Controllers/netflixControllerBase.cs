using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace netflix.Controllers
{
    public abstract class netflixControllerBase: AbpController
    {
        protected netflixControllerBase()
        {
            LocalizationSourceName = netflixConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
