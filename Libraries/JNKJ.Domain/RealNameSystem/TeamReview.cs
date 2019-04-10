using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
	/// 班组评价
	///</summary>
	public class TeamReview : BaseEntity
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
        ///班组编号
        ///</summary>
        public int TeamSysNo { set; get; }
        ///<summary>
        ///质量评价星级，1-5星级
        ///</summary>
        public int Option1 { set; get; }
        ///<summary>
        ///进度评价星级，1-5星级
        ///</summary>
        public int Option2 { set; get; }
        ///<summary>
        ///安全评价星级，1-5星级
        ///</summary>
        public int Option3 { set; get; }
        ///<summary>
        ///预留评价星级，1-5星级
        ///</summary>
        public int Option4 { set; get; }
        ///<summary>
        ///评价说明
        ///</summary>
        public string Note { set; get; }
    }
}
