using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 企业黑名单信息
    ///</summary>
    public class SubContractorBlackList : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///企业系统编号
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///承包方组织机构代码
        ///</summary>
        public string ContractorOrgCode { set; get; }
        ///<summary>
        ///项目编号
        ///</summary>
        public string ProjectCode { set; get; }
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
