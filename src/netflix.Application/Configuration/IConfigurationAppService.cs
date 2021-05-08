using System.Threading.Tasks;
using netflix.Configuration.Dto;

namespace netflix.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
