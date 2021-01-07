using Abp.Application.Services;
using McSaas.MultiTenancy.Dto;

namespace McSaas.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

