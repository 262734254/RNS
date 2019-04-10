using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.RealNameSystem
{
    public class PayRollDetailRequest
    {
        public DateTime? balanceDate { get; set; }
        public string payRollCode { get; set; }
        public string iDCardNumber { get; set; }
        public string payRollBankCardNumber { get; set; }
        public int payStatus { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
