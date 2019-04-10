using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    [Serializable]
    public class SubContractorRequest
    {
        public bool isAdmin { get; set; }
        public Guid subContractorId { get; set; }
        public DateTime? establishDate { get; set; }
        public string companyName { get; set; }
        public string organizationCode { get; set; }
        public string businessStatus { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
