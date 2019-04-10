using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class TeamMasterRequest
    {
        public int teamSysNo { get; set; }
        public string projectCode { get; set; }
        public string organizationCode { get; set; }
        public string teamName { get; set; }
        public string contact { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
