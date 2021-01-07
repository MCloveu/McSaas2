using System.Collections.Generic;
using McSaas.Roles.Dto;

namespace McSaas.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
