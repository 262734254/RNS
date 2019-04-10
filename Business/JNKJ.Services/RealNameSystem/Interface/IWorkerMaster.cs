using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 工人信息--工人实名基础信息
    /// </summary>
    public interface IWorkerMaster
    {
        /// <summary>
        /// Get the WorkerMaster paged list
        /// </summary>
        /// <param name="joinedTime">加入工会时间 : 为空忽略</param>
        /// <param name="workerName">工人姓名 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="cellPhone">手机号码 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerMasterResponse> GetWorkerMasters(DateTime? joinedTime, string workerName = null,
            string iDCardNumber = null, string cellPhone = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerMaster by id
        /// </summary>
        /// <param name="workerMasterId"></param>
        /// <returns></returns>
        WorkerMaster GetWorkerMasterById(Guid workerMasterId);


        /// <summary>
        /// Insert the WorkerMaster
        /// </summary>
        /// <param name="workerMaster"></param>
        /// <returns></returns>
        bool InsertWorkerMaster(WorkerMasterResponse workerMaster);


        /// <summary>
        /// Updates the WorkerMaster
        /// </summary>
        /// <param name="workerMaster"></param>
        /// <returns></returns>
        bool UpdateWorkerMaster(WorkerMaster workerMaster);


        /// <summary>
        /// Delete the WorkerMaster
        /// </summary>
        /// <param name="workerMaster"></param>
        /// <returns></returns>
        bool DeleteWorkerMaster(WorkerMaster workerMaster);
    }
}
