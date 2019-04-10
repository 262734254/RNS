using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 工人实名基础信息
    ///</summary>
    public class WorkerMaster : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///工人姓名
        ///</summary>
        public string WorkerName { set; get; }
        ///<summary>
        ///证件类型，引用附录字典表
        ///</summary>
        public int? IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///工人性别，0=男,1=女
        ///</summary>
        public int? Gender { set; get; }
        ///<summary>
        ///民族，身份证上获取的民族信息，如：汉，回，藏
        ///</summary>
        public string Nation { set; get; }
        ///<summary>
        ///出生日期，身份证上获取的出生日期，格式：1990-04-08
        ///</summary>
        public DateTime? Birthday { set; get; }
        ///<summary>
        ///籍贯
        ///</summary>
        public string BirthPlaceCode { set; get; }
        ///<summary>
        ///住址，身份证上获取的籍贯地址
        ///</summary>
        public string Address { set; get; }
        ///<summary>
        ///头像
        ///</summary>
        public byte[] HeadImage { set; get; }
        ///<summary>
        ///政治面貌，0=中共党员,1=中共预备党员,2=共青团员,3=群众

        ///</summary>
        public int? PoliticsType { set; get; }
        ///<summary>
        ///是否加入工会：0=未加入,1=已加入
        ///</summary>
        public int? IsJoined { set; get; }
        ///<summary>
        ///加入工会时间
        ///</summary>
        public DateTime? JoinedTime { set; get; }
        ///<summary>
        ///手机号码
        ///</summary>
        public string CellPhone { set; get; }
        ///<summary>
        ///文化程度：0=小学,1=初中,2=高中,3=中专,4=大专,5=本科,6=硕士,7=博士,8=文盲
        ///</summary>
        public int? CultureLevelType { set; get; }
        ///<summary>
        ///是否有重大病史：0=无,1=有
        ///</summary>
        public int? HasBadMedicalHistory { set; get; }
        ///<summary>
        ///紧急联系人姓名
        ///</summary>
        public string UrgentContractName { set; get; }
        ///<summary>
        ///紧急联系人联系电话
        ///</summary>
        public string UrgentContractCellphone { set; get; }
        ///<summary>
        ///当前工种，参见工种字典表中工种编号
        ///</summary>
        public string WorkTypeCode { set; get; }
        ///<summary>
        ///开始工作日期
        ///</summary>
        public DateTime? WorkDate { set; get; }
    }

    public class WorkerMasterResponse {

        public Guid Id { set; get; }
        ///<summary>
        ///工人姓名
        ///</summary>
        public string WorkerName { set; get; }
        ///<summary>
        ///证件类型，引用附录字典表
        ///</summary>
        public int? IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///工人性别，0=男,1=女
        ///</summary>
        public int? Gender { set; get; }
        ///<summary>
        ///民族，身份证上获取的民族信息，如：汉，回，藏
        ///</summary>
        public string Nation { set; get; }
        ///<summary>
        ///出生日期，身份证上获取的出生日期，格式：1990-04-08
        ///</summary>
        public DateTime? Birthday { set; get; }
        ///<summary>
        ///籍贯
        ///</summary>
        public string BirthPlaceCode { set; get; }
        ///<summary>
        ///住址，身份证上获取的籍贯地址
        ///</summary>
        public string Address { set; get; }
        ///<summary>
        ///头像
        ///</summary>
        public string HeadImage { set; get; }
        ///<summary>
        ///政治面貌，0=中共党员,1=中共预备党员,2=共青团员,3=群众

        ///</summary>
        public int? PoliticsType { set; get; }
        ///<summary>
        ///是否加入工会：0=未加入,1=已加入
        ///</summary>
        public int? IsJoined { set; get; }
        ///<summary>
        ///加入工会时间
        ///</summary>
        public DateTime? JoinedTime { set; get; }
        ///<summary>
        ///手机号码
        ///</summary>
        public string CellPhone { set; get; }
        ///<summary>
        ///文化程度：0=小学,1=初中,2=高中,3=中专,4=大专,5=本科,6=硕士,7=博士,8=文盲
        ///</summary>
        public int? CultureLevelType { set; get; }
        ///<summary>
        ///是否有重大病史：0=无,1=有
        ///</summary>
        public int? HasBadMedicalHistory { set; get; }
        ///<summary>
        ///紧急联系人姓名
        ///</summary>
        public string UrgentContractName { set; get; }
        ///<summary>
        ///紧急联系人联系电话
        ///</summary>
        public string UrgentContractCellphone { set; get; }
        ///<summary>
        ///当前工种，参见工种字典表中工种编号
        ///</summary>
        public string WorkTypeCode { set; get; }
        ///<summary>
        ///开始工作日期
        ///</summary>
        public DateTime? WorkDate { set; get; }

    }
}
