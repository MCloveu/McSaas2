using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using McSaas.Configuration.Dto;

namespace McSaas.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : McSaasAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
