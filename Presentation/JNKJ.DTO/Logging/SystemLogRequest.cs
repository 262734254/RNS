using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Logging
{
    public class SystemLogRequest
    {
        public DateTime? fromUtc { get; set; }
        public DateTime? toUtc { get; set; }
        public string message { get; set; }
        public int logLevel { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
