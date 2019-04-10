using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 工人信息--工人奖励记录信息
    /// </summary>
    public interface IWorkerGoodRecords
    {
        /// <summary>
        /// Get the WorkerGoodRecords paged list
        /// </summary>
        /// <param name="occurrenceDate">奖励时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerGoodRecords> GetWorkerGoodRecordss(DateTime? occurrenceDate, string projectCode = null,
            string organizationCode = null, string iDCardNumber = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerGoodRecords by id
        /// </summary>
        /// <param name="workerGoodRecordsId"></param>
        /// <returns></returns>
        WorkerGoodRecords GetWorkerGoodRecordsById(Guid workerGoodRecordsId);


        /// <summary>
        /// Insert the WorkerGoodRecords
        /// </summary>
        /// <param name="workerGoodRecords"></param>
        /// <returns></returns>
        bool InsertWorkerGoodRecords(WorkerGoodRecords workerGoodRecords);


        /// <summary>
        /// Updates the WorkerGoodRecords
        /// </summary>
        /// <param name="workerGoodRecords"></param>
        /// <returns></returns>
        bool UpdateWorkerGoodRecords(WorkerGoodRecords workerGoodRecords);


        /// <summary>
        /// Delete the WorkerGoodRecords
        /// </summary>
        /// <param name="workerGoodRecords"></param>
        /// <returns></returns>
        bool DeleteWorkerGoodRecords(WorkerGoodRecords workerGoodRecords);
    }
}
