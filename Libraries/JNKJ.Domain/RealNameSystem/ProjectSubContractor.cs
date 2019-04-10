using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 项目参建单位信息
    ///</summary>
    public class ProjectSubContractor : BaseEntity
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
        ///企业系统组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///参建类型：8专业分包；9设备分包；10材料分包；11后勤服务；12特殊设备；13劳务分包；14监理单位；15建设单位；16总承包单位；17勘察单位；18设计单位；67其它；89租赁
        ///</summary>
        public int? ContractorType { set; get; }
        ///<summary>
        ///进场时间
        ///</summary>
        public DateTime? EntryTime { set; get; }
        ///<summary>
        ///退场时间
        ///</summary>
        public DateTime? ExitTime { set; get; }
        ///<summary>
        ///发放工资的银行名称
        ///</summary>
        public string BankName { set; get; }
        ///<summary>
        ///发放工资的共管银行账户
        ///</summary>
        public string BankNumber { set; get; }
        ///<summary>
        ///银行联号
        ///</summary>
        public string BankLinkNumber { set; get; }
        ///<summary>
        ///工资发放模式
        ///</summary>
        public int PayMode { set; get; }
        ///<summary>
        ///项目经理名称
        ///</summary>
        public string PMName { set; get; }
        ///<summary>
        ///身份类型
        ///</summary>
        public int PMIDCardType { set; get; }
        ///<summary>
        ///身份证号码
        ///</summary>
        public string PMIDCardNumber { set; get; }
        ///<summary>
        ///项目经理电话
        ///</summary>
        public string PMPhone { set; get; }
    }
}
