using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 工资单
    ///</summary>
    public class PayRoll : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///工资单编号.工资单编号18位：GZD+6位分包商系统编号+YYYYMM+3位序号；
        ///</summary>
        public string PayRollCode { set; get; }
        ///<summary>
        ///项目编号
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///所属企业编号
        ///</summary>
        public int OrganizationCode { set; get; }
        ///<summary>
        ///班组编号
        ///</summary>
        public int TeamSysNo { set; get; }
        ///<summary>
        ///发放工资的年月(YYYY-MM)
        ///</summary>
        public DateTime PayMonth { set; get; }
        ///<summary>
        ///状态.2=分包已审核,3=总包已复核，50=已发放
        ///</summary>
        public int Status { set; get; }
        ///<summary>
        ///建筑活动工程编码（总包）.来源JZHD0101
        ///</summary>
        public string ContractorProjectCode { set; get; }
        ///<summary>
        ///建筑活动工程编码（分包）来源JZHD0101
        ///</summary>
        public string SubContractorProjectCode { set; get; }
        ///<summary>
        ///存放工资单附件路径(上传附件时有对应的附件上传接口)
        ///</summary>
        public string AttachFiles { set; get; }
    }
}
