using Abp.Application.Services;
using Abp.Application.Services.Dto;
using McSaas.App.Buildings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McSaas.App.Buildings
{
    public interface IBuildingAppService : IApplicationService
    {
        Task CreateAsync(CreateBuildingDto input);

        Task UpdateAsync(BuildingDto input);

        Task DeleteAsync(EntityDto<int> input);

        Task<ListResultDto<BuildingDto>> GetAllPagedAsync(PagedBuildingResultRequestDto input);

        Task<ListResultDto<BuildingDto>> GetAllAsync();

        Task<BuildingDto> GetAsync(EntityDto<int> input);

        Task<BuildingEditDto> GetEditAsync(EntityDto<int> input);

        Task<ListResultDto<BuildingListDto>> GetBuildingList();
    }
}
