using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using McSaas.Core.Buildings;
using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Houses
{
    public class House : FullAuditedEntity, IMayHaveTenant
    {
        public string Name { get; set; }

        public ICollection<Building> Building { get; set; }

        public int? TenantId { get; set; }
    }
}
