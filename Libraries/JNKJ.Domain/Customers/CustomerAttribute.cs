using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JNKJ.Domain.Customers
{
    /// <summary>
    /// 用户的附加属性类
    /// </summary>
    [Serializable]
    public class CustomerAttribute : BaseEntity
    {
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// 公司名
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string CompanyMobile { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CompanyTelphone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 获取或设置一个用户昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 获取或者设置一个用户头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("Id")]
        public virtual Customer Customer { get; set; }

    }
}
