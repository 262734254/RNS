using System;
using System.Collections.Generic;
using System.Linq;
using JNKJ.Core;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.Customers;
using JNKJ.Domain.Logging;
using JNKJ.Domain.Configuration;
using JNKJ.Data;

namespace JNKJ.Services.Logging
{
    /// <summary>
    /// 默认的日志记录提供者
    /// </summary>
    public partial class DefaultLogger : ILogger
    {
        #region Fields

        private readonly IRepository<Log> _logRepository;
        private readonly IWebHelper _webHelper;
        private readonly IDbContext _dbContext;
        private readonly IDataProvider _dataProvider;
        private readonly CommonSettings _commonSettings;

        #endregion

        #region Ctor

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logRepository">日志库</param>
        /// <param name="webHelper">Web支持类</param>
        /// <param name="dbContext">DB上下文</param>
        /// <param name="dataProvider">WeData提供者</param>
        /// <param name="commonSettings">公共设置类</param>
        public DefaultLogger(IRepository<Log> logRepository,
            IWebHelper webHelper,
            IDbContext dbContext,
            IDataProvider dataProvider,
            CommonSettings commonSettings)
        {
            this._logRepository = logRepository;
            this._webHelper = webHelper;
            this._dbContext = dbContext;
            this._dataProvider = dataProvider;
            this._commonSettings = commonSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 决定是否启用日志级别
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <returns>返回结果</returns>
        public virtual bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 删除一个日志
        /// </summary>
        /// <param name="log">数据实体</param>
        public virtual void DeleteLog(Log log)
        {
            if (log == null)
                throw new ArgumentNullException("log");

            _logRepository.Delete(log);
        }


        /// <summary>
        /// 清理日志
        /// </summary>
        public virtual void ClearLog()
        {
            if (_commonSettings.UseSitedProceduresIfSupported && _dataProvider.sitedProceduredSupported)
            {
                //是否所有的数据库都支持 "Truncate 命令"?
                //TODO: 不要硬编码数据库表名
                _dbContext.ExecuteSqlCommand("TRUNCATE TABLE [Log]");
            }
            else
            {
                var log = _logRepository.Table.ToList();
                foreach (var logItem in log)
                    _logRepository.Delete(logItem);
            }
        }

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
        public virtual IPagedList<Log> GetAllLogs(DateTime? fromUtc, DateTime? toUtc,
            string message, LogLevel? logLevel, int pageIndex, int pageSize)
        {
            #region 判断值
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            #endregion

            var query = _logRepository.Table;
            if (fromUtc.HasValue)
                query = query.Where(l => fromUtc.Value <= l.CreatedOnUtc);
            if (toUtc.HasValue)
                query = query.Where(l => toUtc.Value >= l.CreatedOnUtc);
            if (logLevel.HasValue)
            {
                int logLevelId = (int)logLevel.Value;
                query = query.Where(l => logLevelId == l.LogLevelId);
            }
            if (!string.IsNullOrEmpty(message))
                query = query.Where(l => l.ShortMessage.Contains(message) || l.FullMessage.Contains(message));
            query = query.OrderByDescending(l => l.CreatedOnUtc);

            var log = new PagedList<Log>(query, pageIndex, pageSize);
            return log;
        }

        /// <summary>
        /// 获取一个日志实体
        /// </summary>
        /// <param name="logId">日志标示符</param>
        /// <returns>日志实体</returns>
        public virtual Log GetLogById(Guid logId)
        {
            if (string.IsNullOrEmpty(logId.ToString()))
                return null;

            return _logRepository.GetById(logId);
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="logIds">日志标示符列表</param>
        /// <returns>日志实体</returns>
        public virtual IList<Log> GetLogByIds(Guid[] logIds)
        {
            if (logIds == null || logIds.Length == 0)
                return new List<Log>();

            var query = from l in _logRepository.Table
                        where logIds.Contains(l.Id)
                        select l;
            var logItems = query.ToList();
            //sort by passed identifiers
            var sortedLogItems = new List<Log>();
            foreach (Guid id in logIds)
            {
                var log = logItems.Find(x => x.Id == id);
                if (log != null)
                    sortedLogItems.Add(log);
            }
            return sortedLogItems;
        }

        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="shortMessage">短消息</param>
        /// <param name="fullMessage">完整消息</param>
        /// <param name="customer">关联日志的用户</param>
        /// <returns>记录实体</returns>
        public virtual Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", Customer customer = null)
        {
            var log = new Log()
            {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                IpAddress = _webHelper.GetCurrentIpAddress(),
                Customer = customer,
                PageUrl = _webHelper.GetThisPageUrl(true),
                ReferrerUrl = _webHelper.GetUrlReferrer(),
                CreatedOnUtc = DateTime.UtcNow
            };

            _logRepository.Insert(log);

            return log;
        }

        #endregion
    }
}
