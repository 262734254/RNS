using System;
using System.Collections.Generic;
using JNKJ.Core;
using JNKJ.Domain;
using JNKJ.Domain.Customers;
using JNKJ.Domain.Logging;

namespace JNKJ.Services.Logging
{
    /// <summary>
    /// 日志接口
    /// </summary>
    public partial interface ILogger
    {
        /// <summary>
        /// 决定是否启用日志级别
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns>返回结果</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// 删除一个日志
        /// </summary>
        /// <param name="log">数据实体</param>
        void DeleteLog(Log log);

        /// <summary>
        /// 清理日志
        /// </summary>
        void ClearLog();

        /// <summary>
        ///  获取日志
        /// </summary>
        /// <param name="fromUtc">日志创建时间（开始，空加载全部）</param>
        /// <param name="toUtc">日志创建时间（结束），空加载全部</param>
        /// <param name="message">日志消息</param>
        /// <param name="logLevel">日志级别，空加载全部</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>列表</returns>
        IPagedList<Log> GetAllLogs(DateTime? fromUtc, DateTime? toUtc,
            string message, LogLevel? logLevel, int pageIndex, int pageSize);

        /// <summary>
        /// 获取一个日志实体
        /// </summary>
        /// <param name="logId">日志标示符</param>
        /// <returns>日志实体</returns>
        Log GetLogById(Guid logId);

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="logIds">日志标示符列表</param>
        /// <returns>日志实体</returns>
        IList<Log> GetLogByIds(Guid[] logIds);

        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="shortMessage">短消息</param>
        /// <param name="fullMessage">完整消息</param>
        /// <param name="customer">关联日志的用户</param>
        /// <returns>记录实体</returns>
        Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null);
    }
}
