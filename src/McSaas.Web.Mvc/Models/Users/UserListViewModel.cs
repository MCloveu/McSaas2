using System.Collections.Generic;
using McSaas.Roles.Dto;

namespace McSaas.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
