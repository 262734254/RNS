using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JNKJ.Domain.Customers
{
    [Serializable]
    public class CustomerExtentions : BaseEntity
    {
        #region CustomerExtentions
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 是否是普通用户
        /// </summary>
        public bool IsCustomer { get; set; }
        /// <summary>
        /// 密保邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 密保手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question1 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer1 { get; set; }

        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question2 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer2 { get; set; }
        /// <summary>
        /// 密码提示问题1
        /// </summary>
        public string Question3 { get; set; }
        /// <summary>
        /// 提示问题答案1
        /// </summary>
        public string Answer3 { get; set; }

        [ForeignKey("Id")]
        public virtual Customer Customer { get; set; }
        #endregion

    }
}
