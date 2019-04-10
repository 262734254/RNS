using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--项目参建单位信息
    /// </summary>
    public interface IProjectSubContractor
    {
        /// <summary>
        /// Get the ProjectSubContractor paged list
        /// </summary>
        /// <param name="entryTime">进场时间 : 为空忽略</param>
        /// <param name="exitTime">退场时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业系统组织机构代码 : 为空忽略</param>
        /// <param name="contractorType">参建类型 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<ProjectSubContractor> GetProjectSubContractors(DateTime? entryTime, DateTime? exitTime, string projectCode = null,
            string organizationCode = null, int contractorType = -1, int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the ProjectSubContractor by id
        /// </summary>
        /// <param name="projectSubContractorId"></param>
        /// <returns></returns>
        ProjectSubContractor GetProjectSubContractorById(Guid projectSubContractorId);


        /// <summary>
        ///  Get the ProjectSubContractor by PorjectCode
        /// </summary>
        /// <param name="projectSubContractorId"></param>
        /// <returns></returns>
        ProjectSubContractor GetProjectSubContractorByProjectCode(string projectCode);

        /// <summary>
        /// Insert the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        bool InsertProjectSubContractor(ProjectSubContractor projectSubContractor);


        /// <summary>
        /// Updates the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        bool UpdateProjectSubContractor(ProjectSubContractor projectSubContractor);


        /// <summary>
        /// Delete the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        bool DeleteProjectSubContractor(ProjectSubContractor projectSubContractor);
    }
}
