using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--项目中的培训记录
    /// </summary>
    public interface IProjectTraining
    {
        /// <summary>
        /// Get the ProjectTraining paged list
        /// </summary>
        /// <param name="trainingTime">培训时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="trainingName">课程名称 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<ProjectTraining> GetProjectTrainings(DateTime? trainingTime, string projectCode = null,
            string trainingName = null, int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the ProjectTraining by id
        /// </summary>
        /// <param name="projectTrainingId"></param>
        /// <returns></returns>
        ProjectTraining GetProjectTrainingById(Guid projectTrainingId);

        /// <summary>
        ///  Get the ProjectTraining by ProjectCode
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        ProjectTraining GetProjectTrainingByProjectCode(string ProjectCode);

        /// <summary>
        /// Insert the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns>
        bool InsertProjectTraining(ProjectTraining projectTraining);


        /// <summary>
        /// Updates the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns>
        bool UpdateProjectTraining(ProjectTraining projectTraining);


        /// <summary>
        /// Delete the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns>
        bool DeleteProjectTraining(ProjectTraining projectTraining);
    }
}
