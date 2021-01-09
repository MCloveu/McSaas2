using Abp.Application.Services;
using Abp.Application.Services.Dto;
using McSaas.Communitys.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McSaas.Communitys
{
    public interface ICommunityAppService: IApplicationService
    {
        Task CreateAsync(CreateCommunityDto input);

        Task DeleteAsync(EntityDto<int> input);

        Task<PagedResultDto<CommunityDto>> GetAllPagedAsync(PagedCommunityResultRequestDto input);

        Task<PagedResultDto<CommunityDto>> GetAllAsync();

        Task<CommunityEditDto> GetEditAsync(EntityDto<int> input);

        Task<CommunityDto> GetAsync(EntityDto<int> input);

        Task UpdateAsync(CommunityDto input);

        Task<ListResultDto<CommunityListDto>> GetCommunityList();
    }
}
