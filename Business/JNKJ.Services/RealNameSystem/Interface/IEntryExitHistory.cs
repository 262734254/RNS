using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--进退场记录
    /// </summary>
    public interface IEntryExitHistory
    {
        /// <summary>
        /// Get the EntryExitHistory paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="type">类型 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<EntryExitHistory> GetEntryExitHistorys(string projectCode = null, string organizationCode = null, string iDCardNumber = null, int type = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the EntryExitHistory by id
        /// </summary>
        /// <param name="entryExitHistoryId"></param>
        /// <returns></returns>
        EntryExitHistory GetEntryExitHistoryById(Guid entryExitHistoryId);

        /// <summary>
        ///  Get the EntryExitHistory by ProjectCode
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        EntryExitHistory GetEntryExitHistorysByProjectCode(string ProjectCode);

        /// <summary>
        /// Insert the EntryExitHistory
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        bool InsertEntryExitHistory(EntryExitHistory entryExitHistory);


        /// <summary>
        /// Updates the EntryExitHistory
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        bool UpdateEntryExitHistory(EntryExitHistory entryExitHistory);


        /// <summary>
        /// Delete the EntryExitHistory
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        bool DeleteEntryExitHistory(EntryExitHistory entryExitHistory);
    }
}
