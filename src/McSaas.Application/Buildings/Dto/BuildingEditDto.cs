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
    public class BuildingEditDto:EntityDto<int>
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
        [Required]
        public Community Community { get; set; }

        public int HouseNumber { get; set; }
    }
}
