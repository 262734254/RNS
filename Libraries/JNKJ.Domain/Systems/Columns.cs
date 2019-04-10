using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JNKJ.Domain.Systems
{
    /// <summary>
    /// 系统导航菜单
    /// </summary>
    [Serializable]
    public partial class Columns : BaseEntity
    {
        #region Properties
        [DisplayName("导航类别")]
        /// <summary>
        /// 导航类别
        /// </summary>
        public int ColumnType { get; set; }
        public string ColumnTypeName { get; set; }
        [DisplayName("调用别名")]
        /// <summary>
        /// 导航的keys
        /// </summary>
        public string ColumnKey { get; set; }

        [DisplayName("导航标题")]
        /// <summary>
        /// 标题
        /// </summary>
        public string ColumnTitle { get; set; }

        [DisplayName("导航副标题")]
        /// <summary>
        /// 副标题
        /// </summary>
        public string Subtitle { get; set; }

        [DisplayName("链接地址")]
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }

        [DisplayName("排序数字")]
        /// <summary>
        /// 排序数字
        /// </summary>
        public int SortIndex { get; set; }

        [DisplayName("状态")]
        /// <summary>
        /// 状态 状态，0,新增 1正常  2审核中  3.隐藏  9.删除
        /// </summary>
        public int Status { get; set; }

        [DisplayName("是否显示")]
        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow { get; set; }

        [DisplayName("备注说明")]
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }

        [DisplayName("父导航ID")]
        /// <summary>
        /// 所属父导航ID
        /// </summary>
        public Guid ParentId { get; set; }

        [DisplayName("int列表")]
        /// <summary>
        /// 菜单ID列表(逗号分隔开)
        /// </summary>
        public string ColumnList { get; set; }

        [DisplayName("导航深度")]
        /// <summary>
        /// 导航深度
        /// </summary>
        public int ColumnLayer { get; set; }

        [DisplayName("Seo关键字")]
        /// <summary>
        /// Seo关键字
        /// </summary>
        public string SEOKeywords { get; set; }

        [DisplayName("Seo标题")]
        /// <summary>
        /// 标题
        /// </summary>
        public string SEOTitle { get; set; }

        [DisplayName("Seo描述")]
        /// <summary>
        /// Seo描述
        /// </summary>
        public string SEODescription { get; set; }

        [DisplayName("权限资源")]
        /// <summary>
        /// 权限资源
        /// </summary>
        public string ActionType { get; set; }

        [DisplayName("图标")]
        /// <summary>
        /// 图标
        /// </summary>
        public string IcoUrl { get; set; }

        [DisplayName("系统默认")]
        /// <summary>
        /// 系统默认
        /// </summary>
        public int IsSystem { get; set; }
        /// <summary>
        /// 是否是推荐栏目
        /// </summary>
        public int IsRecommend { get; set; }

        [DisplayName("创建时间")]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        [DisplayName("创建人")]
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; }

        [DisplayName("更新时间")]
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateOnUtc { get; set; }

        [DisplayName("更新用户")]
        /// <summary>
        /// 更新用户
        /// </summary>
        public string Updater { get; set; }
        #endregion
    }
}