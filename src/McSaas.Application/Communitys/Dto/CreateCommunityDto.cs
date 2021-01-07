using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McSaas.Communitys.Dto
{
    [AutoMapTo(typeof(Community))]
    public class CreateCommunityDto
    {
        /// <summary>
        /// 小区名
        /// </summary>
        [Required]
        [StringLength(AppConsts.MaxCommunityNameLength)]
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [StringLength(AppConsts.MaxAddressLength)]
        public string Address { get; set; }

        /// <summary>
        /// 占地面积
        /// </summary>
        public double Area { get; set; }

        /// <summary>
        /// 楼栋数
        /// </summary>
        public int BuildingNumber { get; set; }

        /// <summary>
        /// 房间数
        /// </summary>
        public int HouseNumber { get; set; }
    }
}
