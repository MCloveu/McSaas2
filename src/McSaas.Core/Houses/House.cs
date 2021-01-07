using Abp.Domain.Entities.Auditing;
using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Houses
{
    public class House : FullAuditedEntity
    {
        public string Name { get; set; }

        public Community Community { get; }
    }
}
