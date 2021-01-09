using Abp.Application.Services.Dto;
using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McSaas.Houses.Dto
{
    public class HouseDto : FullAuditedEntityDto
    {
        [Required]
        [StringLength(AppConsts.MaxNameLength)]
        public string Name { get; set; }

        public Community Community { get; set; }

        public int? TenantId { get; set; }
    }
}