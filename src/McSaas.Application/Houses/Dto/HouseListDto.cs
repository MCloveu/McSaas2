using Abp.AutoMapper;
using Abp.Domain.Entities;
using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Houses.Dto
{
    [AutoMap(typeof(House))]
    public class HouseListDto:Entity
    {
        public string Name { get; set; }

        public Community Community { get; set; }
    }
}
