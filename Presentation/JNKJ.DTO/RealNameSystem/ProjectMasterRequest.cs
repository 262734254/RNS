using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class ProjectMasterRequest
    {
        public DateTime? startDate { get; set; }
        public DateTime? completeDate { get; set; }
        public string projectCode { get; set; }
        public string projectName { get; set; }
        public string projectStatus { get; set; }
        public bool isAdmin { get; set; }
        public Guid SubContractorId { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

    }
}
