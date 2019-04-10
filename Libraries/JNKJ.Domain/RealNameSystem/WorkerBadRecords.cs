using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 工人不良行为记录信息
    ///</summary>
    public class WorkerBadRecords : BaseEntity
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
        ///事件类别，参见不良记录的事件类别字典
        ///</summary>
        public string BadRecordTypeCode { set; get; }
        ///<summary>
        ///事件级别，52=轻度,53=一般,54=严重

        ///</summary>
        public int BadRecordLevelType { set; get; }
        ///<summary>
        ///发生时间
        ///</summary>
        public DateTime OccurrenceDate { set; get; }
        ///<summary>
        ///事件发详细缘由
        ///</summary>
        public string Reason { set; get; }
        ///<summary>
        ///事件处理结果
        ///</summary>
        public string ProcessResult { set; get; }
    }
}
