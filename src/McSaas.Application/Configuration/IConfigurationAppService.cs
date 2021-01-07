using System.Threading.Tasks;
using McSaas.Configuration.Dto;

namespace McSaas.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
