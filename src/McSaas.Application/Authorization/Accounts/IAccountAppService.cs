using System.Threading.Tasks;
using Abp.Application.Services;
using McSaas.Authorization.Accounts.Dto;

namespace McSaas.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
