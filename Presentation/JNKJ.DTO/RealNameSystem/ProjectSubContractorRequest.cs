using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class ProjectSubContractorRequest
    {
        public DateTime? entryTime { get; set; }
        public DateTime? exitTime { get; set; }
        public string projectCode { get; set; }
        public string organizationCode { get; set; }
        public int contractorType { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
