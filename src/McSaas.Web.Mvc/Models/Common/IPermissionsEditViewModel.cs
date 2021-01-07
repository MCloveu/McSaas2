using System.Collections.Generic;
using McSaas.Roles.Dto;

namespace McSaas.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}