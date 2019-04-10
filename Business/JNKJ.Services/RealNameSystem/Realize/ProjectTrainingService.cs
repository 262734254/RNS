using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class ProjectTrainingService : IProjectTraining
    {
        #region Fields

        private readonly IRepository<ProjectTraining> _projectTraining;

        #endregion

        #region Ctor

        public ProjectTrainingService(IRepository<ProjectTraining> projectTraining)
        {
            _projectTraining = projectTraining;
        }
        #endregion

        /// <summary>
        /// Delete the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns>
        public bool DeleteProjectTraining(ProjectTraining projectTraining)
        {
            if (projectTraining == null) { throw new ArgumentException("projectTraining is null"); }

            bool result = _projectTraining.Delete(projectTraining);

            return result;
        }

        /// <summary>
        ///  Get the ProjectTraining by id
        /// </summary>
        /// <param name="projectTrainingId"></param>
        /// <returns></returns>
        public ProjectTraining GetProjectTrainingById(Guid projectTrainingId)
        {
            if (Guid.Empty == projectTrainingId) { return null; }

            var customer = _projectTraining.GetById(projectTrainingId);

            return customer;
        }

        public ProjectTraining GetProjectTrainingByProjectCode(string ProjectCode)
        {
            var customer = _projectTraining.Table.FirstOrDefault(s => s.ProjectCode == ProjectCode);

            return customer;
        }

        /// <summary>
        /// Get the ProjectTraining paged list
        /// </summary>
        /// <param name="trainingTime">培训时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="trainingName">课程名称 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<ProjectTraining> GetProjectTrainings(DateTime? trainingTime, string projectCode = null, string trainingName = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _projectTraining.Table;

            if (trainingTime.HasValue)
            {
                query = query.Where(c => trainingTime.Value == c.TrainingTime);
            }
           
            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(trainingName))
            {
                query = query.Where(c => c.TrainingName.Contains(trainingName));
            }

            var list = new PagedList<ProjectTraining>(query.ToList(), pageIndex - 1, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns>
        public bool InsertProjectTraining(ProjectTraining projectTraining)
        {
            if (projectTraining == null) { throw new ArgumentNullException("projectTraining is null"); }

            bool result = _projectTraining.Insert(projectTraining);

            return result;
        }

        /// <summary>
        /// Updates the ProjectTraining
        /// </summary>
        /// <param name="projectTraining"></param>
        /// <returns></returns> 
        public bool UpdateProjectTraining(ProjectTraining projectTraining)
        {
            if (projectTraining == null) { throw new ArgumentNullException("projectTraining is null"); }

            bool result = _projectTraining.SingleUpdate(projectTraining);

            return result;
        }
    }
}
