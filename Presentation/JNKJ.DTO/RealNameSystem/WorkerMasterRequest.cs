using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class WorkerMasterRequest
    {
        public DateTime? joinedTime { get; set; }
        public string workerName { get; set; }
        public string iDCardNumber { get; set; }
        public string cellPhone { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
