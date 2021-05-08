using System.Threading.Tasks;
using Abp.Application.Services;
using netflix.Sessions.Dto;

namespace netflix.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
