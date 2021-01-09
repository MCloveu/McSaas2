using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using McSaas.Communitys;
using McSaas.Communitys.Dto;
using McSaas.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McSaas.Web.Controllers
{
    public class CommunitysController : McSaasControllerBase
    {
        private readonly ICommunityAppService _communityAppService;

        public CommunitysController(ICommunityAppService communityAppService, IRepository<Community> communityRepositor)
        {
            _communityAppService = communityAppService;
        }

        public async Task<IActionResult> Index() => View();
        //public async Task<IActionResult> Index()
        //{
        //    var query = _communityAppService.GetAllAsync();

        //    var dto = new ListResultDto<CommunityDto>(ObjectMapper.Map<List<CommunityDto>>(query));
           
        //    return View(query);
        //}

        public async Task<ActionResult> EditModal(int communityId)
        {
            var dto = await _communityAppService.GetEditAsync(new EntityDto<int>(communityId));
            return PartialView("_EditModal", dto);
        }
    }
}
