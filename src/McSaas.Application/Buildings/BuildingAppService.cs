using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using McSaas.App.Buildings.Dto;
using McSaas.Core.Buildings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace McSaas.App.Buildings
{
    public class BuildingAppService : McSaasAppServiceBase, IBuildingAppService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns></returns>
        private readonly IRepository<Building>  _repository;

        public BuildingAppService(IRepository<Building> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(CreateBuildingDto input)
        {
            //if (!AbpSession.TenantId.HasValue)
            //{
            //    throw new InvalidOperationException("不能添加楼栋!");
            //}
            input.TenantId = 1;// AbpSession.TenantId.Value;
            var building = ObjectMapper.Map<Building>(input);

            await _repository.InsertAsync(building);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(BuildingDto input)
        {
            var entity = await _repository.GetAsync(input.Id);

            var building = input.MapTo(entity);

            await _repository.UpdateAsync(building);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<int> input)
        {
            var building = await _repository.GetAsync(input.Id);

            if (building == null)
            {
                throw new UserFriendlyException("该楼栋不存在，不能再次删除！");
            }

            await _repository.DeleteAsync(building);
        }

        /// <summary>
        /// 返回所有数据，含分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<BuildingDto>> GetAllPagedAsync(PagedBuildingResultRequestDto input)
        {
            var query = await _repository.GetAllListAsync();

            var count = query.Count();

            var dto = new PagedResultDto<BuildingDto>(count, ObjectMapper.Map<List<BuildingDto>>(query));

            return dto;
        }

        /// <summary>
        /// 返回所有数据，含分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ListResultDto<BuildingDto>> GetAllAsync()
        {
            var query = await _repository.GetAllListAsync();

            var dto = new PagedResultDto<BuildingDto>(query.Count, ObjectMapper.Map<List<BuildingDto>>(query));

            return dto;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BuildingDto> GetAsync(EntityDto<int> input)
        {
            var building = await _repository.GetAsync(input.Id);

            return ObjectMapper.Map<BuildingDto>(building);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BuildingEditDto> GetEditAsync(EntityDto<int> input)
        {
            var building = await _repository.GetAsync(input.Id);

            return ObjectMapper.Map<BuildingEditDto>(building);
        }

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<BuildingListDto>> GetBuildingList()
        {
            var query = _repository.GetAll();

            var community = await query.OrderBy("id").ToListAsync();

            var dto = ObjectMapper.Map<List<BuildingListDto>>(community); //new ListResultDto<CommunityListDto>((IReadOnlyList<CommunityListDto>)query);

            return new ListResultDto<BuildingListDto>(dto);
        }
    }
}