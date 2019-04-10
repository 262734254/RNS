using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 工人信息--工人不良行为记录信息
    /// </summary>
    public interface IWorkerBadRecords
    {
        /// <summary>
        /// Get the WorkerBadRecords paged list
        /// </summary>
        /// <param name="occurrenceDate">发生时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerBadRecords> GetWorkerBadRecordss(DateTime? occurrenceDate, string projectCode = null, string organizationCode = null, string iDCardNumber = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerBadRecords by id
        /// </summary>
        /// <param name="workerBadRecordsId"></param>
        /// <returns></returns>
        WorkerBadRecords GetWorkerBadRecordsById(Guid workerBadRecordsId);


        /// <summary>
        /// Insert the WorkerBadRecords
        /// </summary>
        /// <param name="workerBadRecords"></param>
        /// <returns></returns>
        bool InsertWorkerBadRecords(WorkerBadRecords workerBadRecords);


        /// <summary>
        /// Updates the WorkerBadRecords
        /// </summary>
        /// <param name="workerBadRecords"></param>
        /// <returns></returns>
        bool UpdateWorkerBadRecords(WorkerBadRecords workerBadRecords);


        /// <summary>
        /// Delete the WorkerBadRecords
        /// </summary>
        /// <param name="workerBadRecords"></param>
        /// <returns></returns>
        bool DeleteWorkerBadRecords(WorkerBadRecords workerBadRecords);
    }
}
