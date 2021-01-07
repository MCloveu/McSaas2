using McSaas.Communitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace McSaas.Houses.Dto
{
    public class CreateHouseDto
    {
        [Required]
        [StringLength(AppConsts.MaxHouseNameLength)]
        public string Name { get; set; }

        public Community Community { get; set; }

        [Required]
        public int TenantId { get; set; }
    }
}
