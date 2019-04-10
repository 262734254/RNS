using System.Collections.Generic;
using JNKJ.Domain.Security;

namespace JNKJ.Services.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<PermissionRecord> GetPermissions();
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissions();
    }
}
