using System;

namespace JNKJ.Services.Systems
{
    public class ColumnSearch
    {
        /// <summary>
        /// 栏目的标题
        /// </summary>
        public string columnTitle { get; set; }
        /// <summary>
        /// 栏目的keys
        /// </summary>
        public string columnKeys { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public StatusTypes Status { get; set; }

        public ColumnTypes columnType { get; set; }

        public int isShow { get; set; }
        public Guid parentId { get; set; }
        /// <summary>
        /// 是否推荐栏目
        /// </summary>
        public int IsRecommend { get; set; }
        public DateTime createdFromUtc { get; set; }
        public DateTime createdToUtc { get; set; }
        public bool isSort { get; set; }
    }
}
