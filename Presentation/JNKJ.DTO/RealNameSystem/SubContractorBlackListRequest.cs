using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class SubContractorBlackListRequest
    {
        public string organizationCode { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
