using System.Threading.Tasks;
using Abp.Application.Services;
using netflix.Authorization.Accounts.Dto;

namespace netflix.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
