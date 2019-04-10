using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 企业资质
    ///</summary>
    public class SubContractorCertifications : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///系统编号
        ///</summary>
        public int SysNo { set; get; }
        ///<summary>
        ///企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///证书类型
        ///</summary>
        public string CertificationType { set; get; }
        ///<summary>
        ///证书名称
        ///</summary>
        public string CertificationName { set; get; }
        ///<summary>
        ///证书编号
        ///</summary>
        public string CertificationCode { set; get; }
        ///<summary>
        ///证书有效时间(起)
        ///</summary>
        public DateTime ValidBeginDate { set; get; }
        ///<summary>
        ///最近发放日期
        ///</summary>
        public DateTime RecentValidDate { set; get; }
        ///<summary>
        ///证书有效时间(止)
        ///</summary>
        public DateTime ValidEndDate { set; get; }
        ///<summary>
        ///发证机关
        ///</summary>
        public string GrantOrg { set; get; }
        ///<summary>
        ///资质状态.1:有效.2：注销.3：过期.4：降级
        ///</summary>
        public int QualificationStatus { set; get; }
        ///<summary>
        ///资质证书状态.1:有效.2：注销.3：暂扣.4：过期
        ///</summary>
        public int CertificationStatus { set; get; }
    }
}
