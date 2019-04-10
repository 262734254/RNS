using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class TeamReviewRequest
    {
        public string projectCode { get; set; }
        public string organizationCode { get; set; }
        public int teamSysNo { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
