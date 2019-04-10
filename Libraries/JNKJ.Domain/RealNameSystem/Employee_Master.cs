using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
	/// 从业人员基础信息
	///</summary>
	public class Employee_Master : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///姓名
        ///</summary>
        public string EmployeeName { set; get; }
        ///<summary>
        ///证件类型
        ///</summary>
        public int IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///性别.0=男,1=女
        ///</summary>
        public int Gender { set; get; }
        ///<summary>
        ///文化程度:0=小学.1=初中,2=高中,3=中专,4=大专,5=本科,6=硕士,7=博士,8=文盲
        ///</summary>
        public int CultureLevelType { set; get; }
        ///<summary>
        ///民族
        ///</summary>
        public string Nation { set; get; }
        ///<summary>
        ///出生日期
        ///</summary>
        public DateTime Birthday { set; get; }
        ///<summary>
        ///默认头像
        ///</summary>
        public string HeadImagePath { set; get; }
        ///<summary>
        ///住址
        ///</summary>
        public string Address { set; get; }
        ///<summary>
        ///手机号码
        ///</summary>
        public string CellPhone { set; get; }
        ///<summary>
        ///开始工作时间
        ///</summary>
        public DateTime WorkDate { set; get; }
        ///<summary>
        ///当前职称
        ///</summary>
        public int ProfessionalType { set; get; }
        ///<summary>
        ///当前职称等级
        ///</summary>
        public int ProfessionalLevel { set; get; }
    }
}
