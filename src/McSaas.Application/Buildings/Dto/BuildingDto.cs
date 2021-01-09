using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using McSaas.Communitys;
using McSaas.Core.Buildings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McSaas.App.Buildings.Dto
{
    [AutoMap(typeof(Building))]
    public class BuildingDto : FullAuditedEntityDto
    {
        /// <summary>
        /// 楼栋名
        /// </summary>
        [Required]
        [StringLength(AppConsts.MaxBuildingNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 小区
        /// </summary>
        public Community Community { get; set; }

        /// <summary>
        /// 房间数
        /// </summary>
        public int HouseNumber { get; set; }

        public int? TenantId { get; set; }
    }
}
