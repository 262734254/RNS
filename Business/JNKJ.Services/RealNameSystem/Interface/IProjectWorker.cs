using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.ViewModel;
using System;
using static JNKJ.Services.RealNameSystem.Realize.ProjectWorkerService;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--项目中工人信息
    /// </summary>
    public interface IProjectWorker
    {
        /// <summary>
        /// Get the ProjectWorker paged list
        /// </summary>
        /// <param name="IssueCardTime">发卡时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">所属企业组织机构代码 : 为空忽略</param>
        /// <param name="teamSysNo">班组编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="cellPhone">手机号码 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<ProjectWorkerViewModel> GetProjectWorkers(DateTime? IssueCardTime, string projectCode = null,
            string organizationCode = null, string teamSysNo = null, string iDCardNumber = null, string cellPhone = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the ProjectWorker by id
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        ProjectWorker GetProjectWorkerById(Guid projectWorkerId);

        /// <summary>
        ///  Get the ProjectWorker by ProjectCode
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        ProjectWorker GetProjectWorkerByProjectCode(string ProjectCode);

        /// <summary>
        /// Insert the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        bool InsertProjectWorker(ProjectWorker projectWorker);


        /// <summary>
        /// Updates the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        bool UpdateProjectWorker(ProjectWorker projectWorker);


        /// <summary>
        /// Delete the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        bool DeleteProjectWorker(ProjectWorker projectWorker);
    }
}
