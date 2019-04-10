using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 刷卡数据
    ///</summary>
    public class WorkerAttendance : BaseEntity
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
        ///证件类型.工人证件类型.参见人员证件类型字典表
        ///</summary>
        public int IDCardType { set; get; }
        ///<summary>
        ///证件编号.工人的证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///打卡时间.精确到秒
        ///</summary>
        public DateTime? CheckTime { set; get; }
        ///<summary>
        ///打卡类型.1=入场,2=出场
        ///</summary>
        public int CheckType { set; get; }
        ///<summary>
        ///进入通道
        ///</summary>
        public string CheckChannel { set; get; }
        ///<summary>
        ///数据来源:0=设备打卡(如闸机),1=手动输入
        ///</summary>
        public int DataResource { set; get; }
    }
}
