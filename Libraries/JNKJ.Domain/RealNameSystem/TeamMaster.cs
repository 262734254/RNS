using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 班组基础信息
    ///</summary>
    public class TeamMaster : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///班组编号,外部系统与平台对接创建班组后，由系统返回该编号
        ///</summary>
        public int TeamSysNo { set; get; }
        ///<summary>
        ///项目编号,如果来源于项目现场系统，需要填写项目编号
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///所属企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///班组名称
        ///</summary>
        public string TeamName { set; get; }
        ///<summary>
        ///联系人（默认为班组长）
        ///</summary>
        public string TeamLeader { set; get; }
        ///<summary>
        ///联系方式,请填入班组长手机号
        ///</summary>
        public string Contact { set; get; }
        ///<summary>
        ///班组长身份证号码
        ///</summary>
        public string TeamLeaderIDNumber { set; get; }
        ///<summary>
        ///责任人身份证号码
        ///</summary>
        public string ResponsiblePersonIDNumber { set; get; }
        ///<summary>
        ///备注信息
        ///</summary>
        public string Note { set; get; }
    }
}
