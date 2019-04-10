using System;
using System.Collections.Generic;

namespace JNKJ.Domain.Logging
{
    /// <summary>
    /// 记录类型
    /// </summary>
    public partial class ActivityLogType : BaseEntity
    {
        private ICollection<ActivityLog> _activityLog;

        #region Properties

        /// <summary>
        /// key值
        /// </summary>
        public virtual string SystemKeyword { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public virtual string TypeName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool Enabled { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// 日志
        /// </summary>
        public virtual ICollection<ActivityLog> ActivityLog
        {
            get { return _activityLog ?? (_activityLog = new List<ActivityLog>()); }
            protected set { _activityLog = value; }
        }

        #endregion
    }
}
