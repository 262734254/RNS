using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{

    ///<summary>
    /// 工资明细
    ///</summary>
    public class PayRollDetail : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        /// 工资单编号，关联工资单主对象
        ///</summary>
        public string PayRollCode { set; get; }
        ///<summary>
        ///工人证件类型
        ///</summary>
        public int IDCardType { set; get; }
        ///<summary>
        ///证件号码
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///务工工种
        ///</summary>
        public string WorkerType { set; get; }
        ///<summary>
        ///应发金额
        ///</summary>
        public Decimal TotalPayAmount { set; get; }
        ///<summary>
        ///实发金额
        ///</summary>
        public Decimal ActualAmount { set; get; }
        ///<summary>
        ///出勤天数
        ///</summary>
        public int Days { set; get; }
        ///<summary>
        ///总工时
        ///</summary>
        public Decimal WorkHours { set; get; }
        ///<summary>
        ///银行发放日期
        ///</summary>
        public DateTime BalanceDate { set; get; }
        ///<summary>
        ///发放工资银行卡号
        ///</summary>
        public string PayRollBankCardNumber { set; get; }
        ///<summary>
        ///发放工资银行名称
        ///</summary>
        public string PayRollBankName { set; get; }
        ///<summary>
        ///发放工资银行编号
        ///</summary>
        public string PayRollBankCode { set; get; }
        ///<summary>
        ///该人员在本工程累计支付总金额（元）
        ///</summary>
        public Decimal PayTotalAmount { set; get; }
        ///<summary>
        ///该人员在本工程务工累计结算总金额（元）
        ///</summary>
        public Decimal SettleTotalAmount { set; get; }
        ///<summary>
        ///0= NoPaid = 未发放,20=Paid = 已发放,30=PayFaild = 发放失败,40=Retry = 重新发放中
        ///</summary>
        public int PayStatus { set; get; }
    }
}
