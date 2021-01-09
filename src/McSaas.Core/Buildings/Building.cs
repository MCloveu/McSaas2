using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Core.Buildings
{
    public class Building : FullAuditedEntity, IMayHaveTenant
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

        public int? TenantId { get; set; }
    }
}
