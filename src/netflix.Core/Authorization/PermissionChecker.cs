using Abp.Authorization;
using netflix.Authorization.Roles;
using netflix.Authorization.Users;

namespace netflix.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
