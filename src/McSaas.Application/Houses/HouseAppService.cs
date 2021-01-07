using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using McSaas.Houses.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace McSaas.Houses
{
    public class HouseAppService : McSaasAppServiceBase, IHouseAppService
    {
        private readonly IRepository<House> _houseReposity;
        public HouseAppService(IRepository<House> houseReposity) 
        {
            _houseReposity = houseReposity;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(CreateHouseDto input)
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("不能添加楼户!");
            }
            var community = ObjectMapper.Map<House>(input);

            await _houseReposity.InsertAsync(community);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<int> input)
        {
            var community = _houseReposity.GetAsync(input.Id);
            if (community == null)
            {
                throw new UserFriendlyException("该楼户不存在，不能再次删除！");
            }
            await _houseReposity.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 返回所有数据，含分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<HouseDto>> GetAllAsync(PagedHouseResultRequestDto input)
        {
            var query = await _houseReposity.GetAllListAsync();

            var dto = new PagedResultDto<HouseDto>(query.Count, ObjectMapper.Map<List<HouseDto>>(query));

            return dto;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<HouseDto> GetAsync(EntityDto<int> input)
        {
            var query = await _houseReposity.GetAsync(input.Id);

            var dto = ObjectMapper.Map<HouseDto>(query);

            return dto;
        }

        public async Task<ListResultDto<HouseListDto>> GetHouseList()
        {
            var query = _houseReposity.GetAll();

            var community = await query.OrderBy("id").ToListAsync();

            var dto = ObjectMapper.Map<List<HouseListDto>>(community); //new ListResultDto<HouseListDto>((IReadOnlyList<HouseListDto>)query);

            return new ListResultDto<HouseListDto>(dto);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(HouseDto input)
        {
            var entity = await _houseReposity.GetAsync(input.Id);

            var community = input.MapTo(entity);

            await _houseReposity.UpdateAsync(community);
        }

    }
}
