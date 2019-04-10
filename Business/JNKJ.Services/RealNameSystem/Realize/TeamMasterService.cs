using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace JNKJ.Services.RealNameSystem
{
    public class TeamMasterService : ITeamMaster
    {
        #region Fields

        private readonly IRepository<TeamMaster> _teamMasterRepository;

        #endregion

        #region Ctor

        public TeamMasterService(IRepository<TeamMaster> teamMasterRepository)
        {
            _teamMasterRepository = teamMasterRepository;
        }

        #endregion


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
        public IPagedList<TeamMaster> GetTeamMasters(int teamSysNo = -1, string projectCode = null, string organizationCode = null, string teamName = null, string contact = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _teamMasterRepository.Table;

            if (teamSysNo != -1)
            {
                query = query.Where(c => c.TeamSysNo == teamSysNo);
            }
            if (!string.IsNullOrWhiteSpace(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (!string.IsNullOrWhiteSpace(teamName))
            {
                query = query.Where(c => c.TeamName.Contains(teamName));
            }
            if (!string.IsNullOrWhiteSpace(contact))
            {
                query = query.Where(c => c.Contact.Contains(contact));
            }

            query = query.OrderByDescending(c => c.TeamSysNo);

            var list = new PagedList<TeamMaster>(query, pageIndex, pageSize);
            return list;
        }


        /// <summary>
        ///  Get the TeamMaster by id
        /// </summary>
        /// <param name="teamMasterId"></param>
        /// <returns></returns>
        public TeamMaster GetTeamMasterById(Guid teamMasterId)
        {
            if (Guid.Empty == teamMasterId) { return null; }

            var customer = _teamMasterRepository.GetById(teamMasterId);

            return customer;
        }

        /// <summary>
        /// Insert the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        public bool InsertTeamMaster(TeamMaster teamMaster)
        {
            if (teamMaster == null) { throw new ArgumentNullException("teamMaster is null"); }

            bool result = _teamMasterRepository.Insert(teamMaster);

            return result;
        }

        /// <summary>
        /// Updates the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        public bool UpdateTeamMaster(TeamMaster teamMaster)
        {
            if (teamMaster == null) { throw new ArgumentNullException("teamMaster is null"); }

            bool result = _teamMasterRepository.SingleUpdate(teamMaster);

            return result;
        }

        /// <summary>
        /// Delete the TeamMaster
        /// </summary>
        /// <param name="teamMaster"></param>
        /// <returns></returns>
        public bool DeleteTeamMaster(TeamMaster teamMaster)
        {
            if (teamMaster == null) { throw new ArgumentNullException("teamMaster is null"); }

            bool result = _teamMasterRepository.Delete(teamMaster);

            return result;
        }


    }
}
