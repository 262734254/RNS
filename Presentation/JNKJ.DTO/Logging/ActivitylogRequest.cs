using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Logging
{
    public class ActivitylogRequest
    {
        public DateTime? createdOnFrom { get; set; }
        public DateTime? createdOnTo { get; set; }
        public Guid customerId { get; set; }
        public Guid activityLogTypeId { get; set; }
        public int pageIndex { get; set; }

        public int pageSize { get; set; }
    }
}
