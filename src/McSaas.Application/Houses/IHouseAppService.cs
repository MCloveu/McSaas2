using Abp.Application.Services;
using Abp.Application.Services.Dto;
using McSaas.Houses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McSaas.Houses
{
    public interface IHouseAppService: IApplicationService
    {
        Task CreateAsync(CreateHouseDto input);

        Task DeleteAsync(EntityDto<int> input);

        Task<PagedResultDto<HouseDto>> GetAllAsync(PagedHouseResultRequestDto input);

        Task<HouseDto> GetAsync(EntityDto<int> input);

        Task UpdateAsync(HouseDto input);

        Task<ListResultDto<HouseListDto>> GetHouseList();
    }
}
