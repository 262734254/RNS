using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 班组成员
    ///</summary>
    public class TeamMember : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///班组编号
        ///</summary>
        public int TeamSysNo { set; get; }
        ///<summary>
        ///证件类型,参见人员证件类型字典表
        ///</summary>
        public int IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///是否为班组长：0=班组长,1=组员
        ///</summary>
        public int TeamWorkerType { set; get; }
    }
}
