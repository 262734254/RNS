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
    public class ProjectMasterService : IProjectMaster
    {
        #region Fields

        private readonly IRepository<ProjectMaster> _projectMaster;
        private readonly IRepository<SubContractor> _subContractor;
        
        #endregion

        #region Ctor

        public ProjectMasterService(IRepository<ProjectMaster> projectMaster, IRepository<SubContractor> subContractor)
        {
            _projectMaster = projectMaster;
            _subContractor = subContractor;
        }
        
        #endregion


        /// <summary>
        /// Delete the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        public bool DeleteProjectMaster(ProjectMaster projectMaster)
        {
            if (projectMaster == null) { throw new ArgumentException("projectMaster is null"); }

            bool result = _projectMaster.Delete(projectMaster);

            return result;
        }

        /// <summary>
        ///  Get the ProjectMaster by id
        /// </summary>
        /// <param name="projectMasterId"></param>
        /// <returns></returns>
        public ProjectMaster GetProjectMasterById(Guid projectMasterId)
        {
            if (Guid.Empty == projectMasterId) { return null; }

            var customer = _projectMaster.GetById(projectMasterId);

            return customer;
        }

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
        public IPagedList<ProjectMaster> GetProjectMasters(bool isAdmin,DateTime? startDate, DateTime? completeDate, Guid SubContractorId, string projectCode = null, string projectName = null, string projectStatus = null,  int pageIndex = 1, int pageSize = 100)
        {
            var OrganizationCode = "";
            if (!isAdmin)
            {
                OrganizationCode = _subContractor.Table.Where(t => t.Id == SubContractorId).FirstOrDefault().OrganizationCode;
            }
         

            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _projectMaster.Table;

            if (!string.IsNullOrEmpty(OrganizationCode))
            {
                query = query.Where(c => c.ContractorOrgCode == OrganizationCode);
            }
            if (startDate.HasValue)
            {
                query = query.Where(c => startDate.Value == c.StartDate);
            }
            if (completeDate.HasValue)
            {
                query = query.Where(c => completeDate.Value == c.CompleteDate);
            }
            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(projectName))
            {
                query = query.Where(c => c.ProjectName.Contains(projectName));
            }

            //if (!string.IsNullOrEmpty(projectStatus))
            //{
            //    IRepository<DataDictionary> _dataDictionaryRepository = null;

            //    DataDictionaryService dictionary = new DataDictionaryService(_dataDictionaryRepository);

            //    var model = dictionary.GetDataDictionary(pageIndex, pageSize).
            //        Where(c => c.GroupKey == "project_status" && c.SingleOptionLabel == projectStatus).FirstOrDefault();

            //    query = query.Where(c => c.ProjectStatus == model.SingleOptionLabel);

            //}

            query = query.OrderByDescending(c => c.StartDate);
            
            var list = new PagedList<ProjectMaster>(query, pageIndex, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        public bool InsertProjectMaster(ProjectMaster projectMaster)
        {
            if (projectMaster == null) { throw new ArgumentNullException("projectMaster is null"); }

            bool result = _projectMaster.Insert(projectMaster);

            return result;
        }

        /// <summary>
        /// Updates the ProjectMaster
        /// </summary>
        /// <param name="projectMaster"></param>
        /// <returns></returns>
        public bool UpdateProjectMaster(ProjectMaster projectMaster)
        {
            if (projectMaster == null) { throw new ArgumentNullException("projectMaster is null"); }

            bool result = _projectMaster.SingleUpdate(projectMaster);

            return result;
        }
    }
}
