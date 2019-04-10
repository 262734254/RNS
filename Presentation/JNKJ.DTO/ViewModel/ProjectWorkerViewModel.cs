using JNKJ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.ViewModel
{
    public class ProjectWorkerViewModel: BaseEntity
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

        public string UserName { get; set; }

        public string OrganizationCode { set; get; }
        ///<summary>
        ///班组编号
        ///</summary>
        public int? TeamSysNo { set; get; }
        ///<summary>
        ///证件类型，参见人员证件类型字典表
        ///</summary>
        public string IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///当前工种，参见工种字典表中工种编号
        ///</summary>
        public string WorkTypeCode { set; get; }
        ///<summary>
        ///手机号码，工人当前手机号码
        ///</summary>
        public string CellPhone { set; get; }
        ///<summary>
        ///发卡时间，制卡时间
        ///</summary>
        public DateTime? IssueCardTime { set; get; }
        ///<summary>
        ///进场时间
        ///</summary>
        public DateTime? EntryTime { set; get; }
        ///<summary>
        ///退场时间
        ///</summary>
        public DateTime? ExitTime { set; get; }
        ///<summary>
        ///销卡时间
        ///</summary>
        public DateTime? CompleteCardTime { set; get; }
        ///<summary>
        ///门禁卡号
        ///</summary>
        public string CardNumber { set; get; }
        ///<summary>
        ///门禁卡类型：1=正式卡,3=临工卡(指的短期进入工地工作的卡，默认这类工人不会记入工资结算)
        ///</summary>
        public int CardType { set; get; }
        ///<summary>
        ///是否与劳务企业签有劳动合同，0=无，1=有
        ///</summary>
        public int HasContract { set; get; }
        ///<summary>
        ///工人劳动合同编号
        ///</summary>
        public string ContractCode { set; get; }
        ///<summary>
        ///工人住宿类型：0=场外住宿,1=场内住宿
        ///</summary>
        public int WorkerAccommodationType { set; get; }
        ///<summary>
        ///工人角色：1=Employe=职员，2=Worker=工人
        ///</summary>
        public int? WorkerRole { set; get; }
        ///<summary>
        ///工资银行卡号
        ///</summary>
        public string PayRollBankCardNumber { set; get; }
        ///<summary>
        ///工资银行名称
        ///</summary>
        public string PayRollBankName { set; get; }
        ///<summary>
        ///有无购买工伤或意外伤害保险：0=No=无,1=Yes=有
        ///</summary>
        public int HasBuyInsurance { set; get; }
    }
}
