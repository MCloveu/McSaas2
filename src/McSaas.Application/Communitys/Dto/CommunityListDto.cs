using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Communitys.Dto
{
    [AutoMap(typeof(Community))]
    public class CommunityListDto:Entity
    {
        /// <summary>
         /// 小区名
        /// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// 地址
        ///// </summary>
        //public string Address { get; }

        ///// <summary>
        ///// 占地面积
        ///// </summary>
        //public double Area { get; }

        ///// <summary>
        ///// 楼栋数
        ///// </summary>
        //public int BuildingNumber { get; }

        ///// <summary>
        ///// 房间数
        ///// </summary>
        //public int HouseNumber { get; }
    }
}
