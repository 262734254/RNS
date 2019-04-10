using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    /// 数据字典表
    ///</summary>
    public class DataDictionary : BaseEntity
    {
        //      ///<summary>
        /////ID，作为主键
        /////</summary>
        //public Guid Id { set; get; }
        ///<summary>
        ///组的Key。不同的组，Key不能重复。
        ///</summary>
        public string GroupKey { set; get; }
        ///<summary>
        ///组的中文名
        ///</summary>
        public string GroupChineseName { set; get; }
        ///<summary>
        ///单个选项的标签名
        ///</summary>
        public string SingleOptionLabel { set; get; }
        ///<summary>
        ///单个选项的值。注意：外键关联的时候，需要关联此字段（SingleOptionValue），不要关联ID，因为ID无意义，且脱离表，也可正常呈现，只不过是数字而已，弱关联就可以了。
        ///</summary>
        public string SingleOptionValue { set; get; }
    }
}
