using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
	/// 项目中的培训记录
	///</summary>
	public class ProjectTraining : BaseEntity
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
        ///培训时间
        ///</summary>
        public DateTime? TrainingTime { set; get; }
        ///<summary>
        ///培训时长
        ///</summary>
        public int TrainingDuration { set; get; }
        ///<summary>
        ///课程名称
        ///</summary>
        public string TrainingName { set; get; }
        ///<summary>
        ///培训类型
        ///</summary>
        public string TrainingTypeCode { set; get; }
        ///<summary>
        ///培训人
        ///</summary>
        public string Trainer { set; get; }
        ///<summary>
        ///培训简述
        ///</summary>
        public string Description { set; get; }
        ///<summary>
        ///参加培训的工人列表.以JSON格式列出参加培训的所有工人，格式：[{"IDCardType":0, "IDCardNumber":"511026198403057234" },{"IDCardType":0, "IDCardNumber":"511028197811097539" }]
        ///</summary>
        public string Workers { set; get; }
    }
}
