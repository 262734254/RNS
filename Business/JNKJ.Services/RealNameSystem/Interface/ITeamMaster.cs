using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 班组信息--班组基础信息
    /// </summary>
    public interface ITeamMaster
    {
        /// <summary>
        /// Get the TeamMaster paged list
        /// </summary>
        /// <param name="teamSysNo">班组编号 : 为-1时忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">所属企业组织机构代码 : 为空忽略</param>
        /// <param name="teamName">班组名称 : 为空忽略</param>
        /// <param name="contact">联系方式 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<TeamMaster> GetTeamMasters(int teamSysNo = -1, string projectCode = null,
            string organizationCode = null, string teamName = null, string contact = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the TeamMaster by id
        /// </summary>
        /// <param name="teamMasterId"></param>
        /// <returns></returns>
        TeamMaster GetTeamMasterById(Guid teamMasterId);


        /// <summary>
        /// Insert the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        bool InsertTeamMaster(TeamMaster teamMaster);


        /// <summary>
        /// Updates the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        bool UpdateTeamMaster(TeamMaster teamMaster);


        /// <summary>
        /// Delete the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        bool DeleteTeamMaster(TeamMaster teamMaster);
    }
}
