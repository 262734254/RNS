using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class TeamMemberRequest
    {
        public int teamSysNo { get; set; }
        public string iDCardNumber { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
