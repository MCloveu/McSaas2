using Abp.AutoMapper;
using Abp.Domain.Entities;
using McSaas.Communitys;
using McSaas.Core.Buildings;
using System.Collections.Generic;

namespace McSaas.App.Buildings.Dto
{
    [AutoMap(typeof(Building))]
    public class BuildingListDto: Entity<int>
    {
        /// <summary>
        /// 楼栋名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 小区
        /// </summary>
        public Community Community { get; set; }

        public int HouseNumber { get; set; }
    }
}
