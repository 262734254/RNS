using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 人员资格证书信息
    ///</summary>
    public class PersonalCertifications : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///证件类型
        ///</summary>
        public int? IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///证书类型
        ///</summary>
        public string CertificationTypeCode { set; get; }
        ///<summary>
        ///专业编码
        ///</summary>
        public int? ProfessionCode { set; get; }
        ///<summary>
        ///类别/工种
        ///</summary>
        public int? JobType { set; get; }
        ///<summary>
        ///证书等级
        ///</summary>
        public int? CertificationLevelType { set; get; }
        ///<summary>
        ///证书名称
        ///</summary>
        public string CertificationName { set; get; }
        ///<summary>
        ///证书有效起始日期。精确到天，如2014-03-19
        ///</summary>
        public DateTime? ValidBeginDate { set; get; }
        ///<summary>
        ///证书有效截止日期。精确到天，如2018-03-19
        ///</summary>
        public DateTime? ValidEndDate { set; get; }
        ///<summary>
        ///发证机关
        ///</summary>
        public string IssueBy { set; get; }
        ///<summary>
        ///发证日期
        ///</summary>
        public DateTime? IssueDate { set; get; }
        ///<summary>
        ///资格状态:1：有效  2：注销3：过期
        ///</summary>
        public int? Status { set; get; }
    }
}
