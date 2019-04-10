using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class PersonalCertificationsRequest
    {
        public DateTime? issueDate { get; set; }
        public string iDCardNumber { get; set; }
        public int professionCode { get; set; }
        public int jobType { get; set; }
        public int status { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
