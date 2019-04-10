using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    ///<summary>
    ///	合同附件表
    ///</summary>
    public class ContractFile : BaseEntity
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
        ///企业组织机构代码
        ///</summary>
        public string OrganizationCode { set; get; }
        ///<summary>
        ///合同编号
        ///</summary>
        public string ContractCode { set; get; }
        ///<summary>
        ///证件类型
        ///</summary>
        public string IDCardType { set; get; }
        ///<summary>
        ///证件编号
        ///</summary>
        public string IDCardNumber { set; get; }
        ///<summary>
        ///附件名称
        ///</summary>
        public string FileName { set; get; }
        ///<summary>
        ///附件文件地址
        ///</summary>
        public string FilePath { set; get; }
    }
}
