using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace McSaas.App.Buildings.Dto
{
    public class PagedBuildingResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
