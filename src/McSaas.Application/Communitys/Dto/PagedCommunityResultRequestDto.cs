using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.Communitys.Dto
{
    public class PagedCommunityResultRequestDto: PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
