using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 班组信息--班组成员
    /// </summary>
    public interface ITeamMember
    {
        /// <summary>
        /// Get the TeamMember paged list
        /// </summary>
        /// <param name="teamSysNo">班组编号 : 为-1时忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<TeamMember> GetTeamMembers(int teamSysNo = -1, string iDCardNumber = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the TeamMember by id
        /// </summary>
        /// <param name="teamMemberId"></param>
        /// <returns></returns>
        TeamMember GetTeamMemberById(Guid teamMemberId);


        /// <summary>
        /// Insert the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        bool InsertTeamMember(TeamMember teamMember);


        /// <summary>
        /// Updates the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        bool UpdateTeamMember(TeamMember teamMember);


        /// <summary>
        /// Delete the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        bool DeleteTeamMember(TeamMember teamMember);
    }
}
