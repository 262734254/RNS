using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.ViewModel;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--刷卡数据
    /// </summary>
    public interface IWorkerAttendance
    {
        /// <summary>
        /// Get the WorkerAttendance paged list
        /// </summary>
        /// <param name="checkTime">打卡时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerAttendanceViewModel> GetWorkerAttendances(DateTime? checkTime, string projectCode = null, string iDCardNumber = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerAttendance by id
        /// </summary>
        /// <param name="workerAttendanceId"></param>
        /// <returns></returns>
        WorkerAttendance GetWorkerAttendanceById(Guid workerAttendanceId);

        /// <summary>
        ///  Get the WorkerAttendance by ProjectCode
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        WorkerAttendance GetWorkerAttendanceByProjectCode(string ProjectCode);

        /// <summary>
        /// Insert the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        bool InsertWorkerAttendance(WorkerAttendance workerAttendance);


        /// <summary>
        /// Updates the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        bool UpdateWorkerAttendance(WorkerAttendance workerAttendance);


        /// <summary>
        /// Delete the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        bool DeleteWorkerAttendance(WorkerAttendance workerAttendance);
    }
}
