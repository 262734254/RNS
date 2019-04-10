using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 项目中工人劳动合同信息
    ///</summary>
    public class WorkerContractRule : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///项目编号
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///所属企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///证件类型.参见人员证件类型字典表
        ///</summary>
        public string IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///合同编号
        ///</summary>
        public string ContractCode { set; get; }
        ///<summary>
        ///合同期限类型
        ///</summary>
        public int ContractPeriodType { set; get; }
        ///<summary>
        ///开始日期
        ///</summary>
        public DateTime? StartDate { set; get; }
        ///<summary>
        ///结束时期
        ///</summary>
        public DateTime? EndDate { set; get; }
        ///<summary>
        ///结算方式.0=计时,1=计天,2=计量,3=包月,4=定额,5=其它
        ///</summary>
        public int PayRollRuleType { set; get; }
        ///<summary>
        ///计量单位.为计量时，计量单位：80=米,81=平方米,82=立方米
        ///</summary>
        public int UnitTypeSysNo { set; get; }
        ///<summary>
        ///单价.根据结算方式，对应的单价
        ///</summary>
        public Decimal UnitPrice { set; get; }
    }
}
