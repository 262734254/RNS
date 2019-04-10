using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class PayRollRequest
    {
        public DateTime? payMonth { get; set; }
        public string payRollCode { get; set; }
        public string projectCode { get; set; }
        public int organizationCode { get; set; }
        public int teamSysNo { get; set; }
        public int? status { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
