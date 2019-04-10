using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--项目基础信息
    /// </summary>
    public interface IProjectMaster
    {
        /// <summary>
        /// Get the ProjectMaster paged list
        /// </summary>
        /// <param name="startDate">开工日期 : 为空忽略</param>
        /// <param name="completeDate">竣工日期 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="projectName">项目名称 : 为空忽略</param>
        /// <param name="projectStatus">状态 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<ProjectMaster> GetProjectMasters(bool isAdmin,DateTime? startDate, DateTime? completeDate, Guid SubContractorId, string projectCode = null,
            string projectName = null, string projectStatus = null,int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the ProjectMaster by id
        /// </summary>
        /// <param name="projectMasterId"></param>
        /// <returns></returns>
        ProjectMaster GetProjectMasterById(Guid projectMasterId);


        /// <summary>
        /// Insert the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        bool InsertProjectMaster(ProjectMaster projectMaster);


        /// <summary>
        /// Updates the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        bool UpdateProjectMaster(ProjectMaster projectMaster);


        /// <summary>
        /// Delete the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        bool DeleteProjectMaster(ProjectMaster projectMaster);
    }
}
