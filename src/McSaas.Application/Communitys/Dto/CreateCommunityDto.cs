using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace McSaas.Communitys.Dto
{
    [AutoMapTo(typeof(Community))]
    public class CreateCommunityDto
    {
         const string re = "/ ^[0 - 9] +$/";
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
        public int BuildingNumber(double number)
        {
            if (!new Regex(re).IsMatch(number.ToString()))
            {
                throw new UserFriendlyException("楼栋数必须为正整数");
            }
            return int.Parse(number.ToString());
        }

        /// <summary>
        /// 房间数
        /// </summary>
        public int HouseNumber(double number)
        {
            if (!new Regex(re).IsMatch(number.ToString()))
            {
                throw new UserFriendlyException("房间数必须为正整数");
            }
            return int.Parse(number.ToString());
        }

        [Required]
        public int TenantId { get; set; }
    }
}
