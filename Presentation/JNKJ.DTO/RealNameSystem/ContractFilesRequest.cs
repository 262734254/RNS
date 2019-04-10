using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    [Serializable]
    public class ContractFilesRequest
    {
        public string projectCode { get; set; }
        public string organizationCode { get; set; }
        public string contractCode { get; set; }
        public string iDCardNumber { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}

