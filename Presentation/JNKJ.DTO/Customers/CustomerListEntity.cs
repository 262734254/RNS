using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Dto.Customers
{
    public class CustomerListEntity
    {
        /// <summary>
        /// 获取或设置一个用户名
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// 获取或设置一个邮箱地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
    }
}
