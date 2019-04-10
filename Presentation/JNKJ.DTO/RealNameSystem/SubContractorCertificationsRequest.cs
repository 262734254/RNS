using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    [Serializable]
    public class SubContractorCertificationsRequest
    {
        public string certificationName { get; set; }
        public string organizationCode { get; set; }
        public int qualificationStatus { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
