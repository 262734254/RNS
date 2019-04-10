using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class Employee_MasterRequest
    {
        public DateTime? birthday { get; set; }
        public string employeeName { get; set; }
        public string cellPhone { get; set; }
        public int professionalType { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

    }
}
