using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
	/// 项目基础信息
	///</summary>
	public class ProjectMaster : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///项目编号，参见编码规则中建筑活动工程编号
        ///</summary>
        public string ProjectCode { set; get; }
        ///<summary>
        ///建设项目编码，参见编码规则中建设项目编码说明
        ///</summary>
        public string BuildProjectCode { set; get; }
        ///<summary>
        ///承包单位组织机构代码
        ///</summary>
        public string ContractorOrgCode { set; get; }
        ///<summary>
        ///承包单位编号
        ///</summary>
        public string GeneralContractorCode { set; get; }
        ///<summary>
        ///承包单位名称
        ///</summary>
        public string GeneralContractorName { set; get; }
        ///<summary>
        ///项目名称
        ///</summary>
        public string ProjectName { set; get; }
        ///<summary>
        ///项目活动类型，参见项目活动类型字典表
        ///</summary>
        public string ProjectActivityType { set; get; }
        ///<summary>
        ///项目简介
        ///</summary>
        public string ProjectDescription { set; get; }
        ///<summary>
        ///项目分类，参见项目分类字典表
        ///</summary>
        public string ProjectCategory { set; get; }
        ///<summary>
        ///是否是重点项目
        ///</summary>
        public int IsMajorProject { set; get; }
        ///<summary>
        ///建设单位名称
        ///</summary>
        public string OwnerName { set; get; }
        ///<summary>
        ///建设单位组织机构代码或统一社会信用代码
        ///</summary>
        public string BuildCorporationCode { set; get; }
        ///<summary>
        ///施工许可证编号
        ///</summary>
        public string BuilderLicenceNum { set; get; }
        ///<summary>
        ///项目所在地，项目行政区划,参见地区字典数据
        ///</summary>
        public string AreaCode { set; get; }
        ///<summary>
        ///承包合同额，单位：（万元）
		///</summary>
		public Decimal TotalContractAmt { set; get; }
        ///<summary>
        ///建筑面积，单位：平方米
        ///</summary>
        public Decimal BuildingArea { set; get; }
        ///<summary>
        ///开工日期，精确到天，格式：yyyy-mm-dd
        ///</summary>
        public DateTime? StartDate { set; get; }
        ///<summary>
        ///竣工日期，精确到天，格式：yyyy-mm-dd
        ///</summary>
        public DateTime? CompleteDate { set; get; }
        ///<summary>
        ///项目来源
        ///</summary>
        public string ProjectSource { set; get; }
        ///<summary>
        ///状态，参见项目状态字典表
        ///</summary>
        public string ProjectStatus { set; get; }
    }
}
