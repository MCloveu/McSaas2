using System.Threading.Tasks;
using Abp.Application.Services;
using McSaas.Sessions.Dto;

namespace McSaas.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
