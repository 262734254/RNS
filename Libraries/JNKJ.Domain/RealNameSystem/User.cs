using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.RealNameSystem
{
    public class User : BaseEntity
    {
        ///<summary>
        ///所属企业Id
        ///</summary>
        public Guid? SubContractorId { set; get; }
        ///<summary>
        ///用户名
        ///</summary>
        public string UserName { set; get; }
        ///<summary>
        ///登录密码
        ///</summary>
        public string Password { set; get; }
        ///<summary>
        ///用户头像
        ///</summary>
        public string UserImgUrl { set; get; }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        ///<summary>
        ///备注
        ///</summary>
        public string Remark { set; get; }
    }
}
