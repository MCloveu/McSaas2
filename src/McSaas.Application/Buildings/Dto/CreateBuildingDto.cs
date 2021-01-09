using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using McSaas.Communitys;
using McSaas.Core.Buildings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McSaas.App.Buildings.Dto
{
    [AutoMapTo(typeof(Building))]
    public class CreateBuildingDto
    {  /// <summary>
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

        /// <summary>
        /// 房间数
        /// </summary>
        public int HouseNumber { get; set; }

        public int? TenantId { get; set; }
    }
}
