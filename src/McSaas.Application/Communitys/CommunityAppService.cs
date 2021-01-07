using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using McSaas.Communitys.Dto;
using McSaas.Editions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace McSaas.Communitys
{
    public class CommunityAppService : McSaasAppServiceBase, ICommunityAppService
    {
        private readonly IRepository<Community, int> _communityRepository;

        public CommunityAppService(IRepository<Community, int> communityRepository)
        {
            _communityRepository = communityRepository;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateAsync(CreateCommunityDto input)
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("不能添加小区!");
            }

            var community = ObjectMapper.Map<Community>(input);

            await _communityRepository.InsertAsync(community);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteAsync(EntityDto<int> input)
        {
            var community = _communityRepository.GetAsync(input.Id);
            if (community == null)
            {
                throw new UserFriendlyException("该小区不存在，不能再次删除！");
            }
            await _communityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 返回所有数据，含分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CommunityDto>> GetAllAsync(PagedCommunityResultRequestDto input)
        {
            var query = await _communityRepository.GetAllListAsync();

            var dto = new PagedResultDto<CommunityDto>(query.Count, ObjectMapper.Map<List<CommunityDto>>(query));

            return dto;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<CommunityDto> GetAsync(EntityDto<int> input)
        {
            var query = await _communityRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<CommunityDto>(query);

            return dto;
        }

        public async Task<ListResultDto<CommunityListDto>> GetCommunityList()
        {
            var query = _communityRepository.GetAll();

            var community = await query.OrderBy("id").ToListAsync(); 

            var dto = ObjectMapper.Map<List<CommunityListDto>>(community); //new ListResultDto<CommunityListDto>((IReadOnlyList<CommunityListDto>)query);

            return new ListResultDto<CommunityListDto>(dto);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateAsync(CommunityDto input)
        {
            var entity = await _communityRepository.GetAsync(input.Id);

            var community = input.MapTo(entity);

            await _communityRepository.UpdateAsync(community);
        }

        /// <summary>
        /// 获取下拉列表
        /// </summary>
        /// <returns></returns>
        //public async Task<ListResultDto<CommunityListDto>> GetCommunityList()
        //{

        //}
    }
}
