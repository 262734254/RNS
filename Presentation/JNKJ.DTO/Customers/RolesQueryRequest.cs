using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Customers
{
    public class RolesQueryRequest
    {
       public string roleName { get; set; }
       public bool IsSystem { get; set; }
       public bool IsActive { get; set; }
       public bool showHidden { get; set; }
        public string RoleType { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; } 
    }
}
