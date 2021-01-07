using Abp.Authorization;
using McSaas.Authorization.Roles;
using McSaas.Authorization.Users;

namespace McSaas.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
