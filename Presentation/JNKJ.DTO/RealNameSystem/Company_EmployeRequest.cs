using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class Company_EmployeRequest
    {
        public bool isAdmin { get; set; }
        public Guid subContractorId { get; set; }
        public DateTime? hireDate { get; set; }
        public DateTime? terminationDate { get; set; }
        public string organizationCode { get; set; }
        public int jobStatus { get; set; }
        public int workerRole { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
