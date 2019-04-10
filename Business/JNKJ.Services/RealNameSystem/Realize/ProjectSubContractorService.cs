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
    public class ProjectSubContractorService : IProjectSubContractor
    {
        #region Fields

        private readonly IRepository<ProjectSubContractor> _projectSubContractor;

        #endregion

        #region Ctor

        public ProjectSubContractorService(IRepository<ProjectSubContractor> projectSubContractor)
        {
            _projectSubContractor = projectSubContractor;
        }

        #endregion

        /// <summary>
        /// Delete the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        public bool DeleteProjectSubContractor(ProjectSubContractor projectSubContractor)
        {
            if (projectSubContractor == null) { throw new ArgumentException("projectSubContractor is null"); }

            bool result = _projectSubContractor.Delete(projectSubContractor);

            return result;
        }

        /// <summary>
        ///  Get the ProjectSubContractor by id
        /// </summary>
        /// <param name="projectSubContractorId"></param>
        /// <returns></returns>
        public ProjectSubContractor GetProjectSubContractorById(Guid projectSubContractorId)
        {
            if (Guid.Empty == projectSubContractorId) { return null; }

            var customer = _projectSubContractor.GetById(projectSubContractorId);

            return customer;
        }

        public ProjectSubContractor GetProjectSubContractorByProjectCode(string projectCode)
        {
            var customer = _projectSubContractor.Table.FirstOrDefault(s => s.ProjectCode == projectCode);

            return customer;
        }

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
        public IPagedList<ProjectSubContractor> GetProjectSubContractors(DateTime? entryTime, DateTime? exitTime, string projectCode = null, string organizationCode = null, int contractorType = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _projectSubContractor.Table;

            if (entryTime.HasValue)
            {
                query = query.Where(c => entryTime.Value == c.EntryTime);
            }
            if (exitTime.HasValue)
            {
                query = query.Where(c => exitTime.Value == c.ExitTime);
            }
            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (contractorType>1)
            {
                query = query.Where(c => c.ContractorType == contractorType);
            }
            

            var list = new PagedList<ProjectSubContractor>(query.ToList(), pageIndex-1, pageSize);
            return list;
        }


        /// <summary>
        /// Insert the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        public bool InsertProjectSubContractor(ProjectSubContractor projectSubContractor)
        {
            if (projectSubContractor == null) { throw new ArgumentNullException("projectSubContractor is null"); }

            bool result = _projectSubContractor.Insert(projectSubContractor);

            return result;
        }

        /// <summary>
        /// Updates the ProjectSubContractor
        /// </summary>
        /// <param name="projectSubContractor"></param>
        /// <returns></returns>
        public bool UpdateProjectSubContractor(ProjectSubContractor projectSubContractor)
        {
            if (projectSubContractor == null) { throw new ArgumentNullException("projectSubContractor is null"); }

            bool result = _projectSubContractor.SingleUpdate(projectSubContractor);

            return result;
        }
    }
}
