using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 班组信息--班组评价
    /// </summary>
    public interface ITeamReview
    {
        /// <summary>
        /// Get the TeamReview paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">所属企业组织机构代码 : 为空忽略</param>
        /// <param name="teamSysNo">班组编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<TeamReview> GetTeamReviews(string projectCode = null, string organizationCode = null, int teamSysNo = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the TeamReview by id
        /// </summary>
        /// <param name="teamReviewId"></param>
        /// <returns></returns>
        TeamReview GetTeamReviewById(Guid teamReviewId);


        /// <summary>
        /// Insert the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        bool InsertTeamReview(TeamReview teamReview);


        /// <summary>
        /// Updates the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        bool UpdateTeamReview(TeamReview teamReview);


        /// <summary>
        /// Delete the TeamReview
        /// </summary>
        /// <param name="teamReview"></param>
        /// <returns></returns>
        bool DeleteTeamReview(TeamReview teamReview);
    }
}
