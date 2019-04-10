using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 工人黑名单信息
    ///</summary>
    public class WorkerBlackList : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///证件类型，参见人员证件类型字典表
        ///</summary>
        public int? IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///项目编号，参见项目基础信息中对项目编号的定义 
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///承包方组织机构代码
        ///</summary>
        public string ContractorOrgCode { set; get; }
        ///<summary>
        ///企业组织机构代码，工人在该项目中所属企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///所在班组编号
        ///</summary>
        public int? TeamSysNo { set; get; }
        ///<summary>
        ///班组名称
        ///</summary>
        public string TeamName { set; get; }
        ///<summary>
        ///黑名单原因
        ///</summary>
        public string BlackReason { set; get; }
        ///<summary>
        ///备注信息
        ///</summary>
        public string Note { set; get; }
    }
}
