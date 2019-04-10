using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 工人信息--工人黑名单信息
    /// </summary>
    public interface IWorkerBlackList
    {
        /// <summary>
        /// Get the WorkerBlackList paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="teamSysNo">所在班组编号 : -1忽略</param>
        /// <param name="teamName">班组名称 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerBlackList> GetWorkerBlackLists(string projectCode = null, string organizationCode = null, string iDCardNumber = null,
            int teamSysNo = -1, string teamName = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerBlackList by id
        /// </summary>
        /// <param name="workerBlackListId"></param>
        /// <returns></returns>
        WorkerBlackList GetWorkerBlackListById(Guid workerBlackListId);


        /// <summary>
        /// Insert the WorkerBlackList
        /// </summary>
        /// <param name="workerBlackList"></param>
        /// <returns></returns>
        bool InsertWorkerBlackList(WorkerBlackList workerBlackList);


        /// <summary>
        /// Updates the WorkerBlackList
        /// </summary>
        /// <param name="workerBlackList"></param>
        /// <returns></returns>
        bool UpdateWorkerBlackList(WorkerBlackList workerBlackList);


        /// <summary>
        /// Delete the WorkerBlackList
        /// </summary>
        /// <param name="workerBlackList"></param>
        /// <returns></returns>
        bool DeleteWorkerBlackList(WorkerBlackList workerBlackList);
    }
}
