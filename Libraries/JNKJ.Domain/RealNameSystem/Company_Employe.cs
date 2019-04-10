using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    /// <summary>
    /// 企业从业人员聘用关系表
    /// </summary>
    public class Company_Employe : BaseEntity
    {
  //      ///<summary>
		/////ID，作为主键
		/////</summary>
		//public Guid Id { set; get; }
        ///<summary>
        ///公司编码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///企业人员系统编号
        ///</summary>
        public int EmployeSysNo { set; get; }
        ///<summary>
        ///岗位职务
        ///</summary>
        public string Job { set; get; }
        ///<summary>
        ///聘用方式.0=All=全职
        ///</summary>
        public int JobType { set; get; }
        ///<summary>
        ///状态.0=Invalid=离职,1=Valid=在职,2=Retire=退休
        ///</summary>
        public int JobStatus { set; get; }
        ///<summary>
        ///入职日期
        ///</summary>
        public DateTime HireDate { set; get; }
        ///<summary>
        ///离职日期
        ///</summary>
        public DateTime? TerminationDate { set; get; }
        ///<summary>
        ///角色.1=Employe=职员.2=Worker=工人
        ///</summary>
        public int WorkerRole { set; get; }
        ///<summary>
        ///备注信息
        ///</summary>
        public string Remark { set; get; }
    }
}
