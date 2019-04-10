using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class TeamReviewService : ITeamReview
    {
        #region Fields

        private readonly IRepository<TeamReview> _teamReviewRepository;

        #endregion

        #region Ctor

        public TeamReviewService(IRepository<TeamReview> teamReviewRepository)
        {
            _teamReviewRepository = teamReviewRepository;
        }

        #endregion


        /// <summary>
        /// Get the TeamReview paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">所属企业组织机构代码 : 为空忽略</param>
        /// <param name="teamSysNo">班组编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<TeamReview> GetTeamReviews(string projectCode = null, string organizationCode = null, int teamSysNo = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _teamReviewRepository.Table;

            if (!string.IsNullOrWhiteSpace(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (teamSysNo != -1)
            {
                query = query.Where(c => c.TeamSysNo == teamSysNo);
            }

            query = query.OrderByDescending(c => c.TeamSysNo);

            var list = new PagedList<TeamReview>(query, pageIndex, pageSize);
            return list;
        }


        /// <summary>
        ///  Get the TeamReview by id
        /// </summary>
        /// <param name="teamReviewId"></param>
        /// <returns></returns>
        public TeamReview GetTeamReviewById(Guid teamReviewId)
        {
            if (Guid.Empty == teamReviewId) { return null; }

            var customer = _teamReviewRepository.GetById(teamReviewId);

            return customer;
        }

        /// <summary>
        /// Insert the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        public bool InsertTeamReview(TeamReview teamReview)
        {
            if (teamReview == null) { throw new ArgumentNullException("teamReview is null"); }

            bool result = _teamReviewRepository.Insert(teamReview);

            return result;
        }

        /// <summary>
        /// Updates the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        public bool UpdateTeamReview(TeamReview teamReview)
        {
            if (teamReview == null) { throw new ArgumentNullException("teamReview is null"); }

            bool result = _teamReviewRepository.SingleUpdate(teamReview);

            return result;
        }

        /// <summary>
        /// Delete the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        public bool DeleteTeamReview(TeamReview teamReview)
        {
            if (teamReview == null) { throw new ArgumentNullException("teamReview is null"); }

            bool result = _teamReviewRepository.Delete(teamReview);

            return result;
        }

    }
}
