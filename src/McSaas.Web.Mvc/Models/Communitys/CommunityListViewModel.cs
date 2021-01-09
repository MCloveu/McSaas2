using McSaas.Communitys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McSaas.Web.Models.Communitys
{
    public class CommunityListViewModel
    {
        public IReadOnlyList<CommunityDto> communities { get; set; }

    }
}
