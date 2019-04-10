using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 工人奖励记录信息
    ///</summary>
    public class WorkerGoodRecords : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///证件类型，参见人员证件类型字典表
        ///</summary>
        public int IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///项目编号，参见项目基础信息中对项目编号的定义 
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///企业组织机构代码，工人在该项目中所属企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///奖励类型，参见奖励类型字典
        ///</summary>
        public string GoodRecordTypeCode { set; get; }
        ///<summary>
        ///奖励级别，58=国家级；59=省部级；60=地市级；61=企业级
        ///</summary>
        public int GoodRecordLevelType { set; get; }
        ///<summary>
        ///奖励时间
        ///</summary>
        public DateTime OccurrenceDate { set; get; }
        ///<summary>
        ///奖项说明
        ///</summary>
        public string Details { set; get; }
    }
}
