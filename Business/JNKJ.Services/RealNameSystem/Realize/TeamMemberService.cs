using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    public class TeamMemberService : ITeamMember
    {
        #region Fields

        private readonly IRepository<TeamMember> _teamMemberRepository;

        #endregion

        #region Ctor

        public TeamMemberService(IRepository<TeamMember> teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        #endregion


        /// <summary>
        /// Get the TeamMember paged list
        /// </summary>
        /// <param name="teamSysNo">班组编号 : 为-1时忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<TeamMember> GetTeamMembers(int teamSysNo = -1, string iDCardNumber = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _teamMemberRepository.Table;

            if (teamSysNo != -1)
            {
                query = query.Where(c => c.TeamSysNo == teamSysNo);
            }
            if (!string.IsNullOrWhiteSpace(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }

            query = query.OrderByDescending(c => c.TeamSysNo);

            var list = new PagedList<TeamMember>(query, pageIndex, pageSize);
            return list;
        }


        /// <summary>
        ///  Get the TeamMember by id
        /// </summary>
        /// <param name="teamMemberId"></param>
        /// <returns></returns>
        public TeamMember GetTeamMemberById(Guid teamMemberId)
        {
            if (Guid.Empty == teamMemberId) { return null; }

            var customer = _teamMemberRepository.GetById(teamMemberId);

            return customer;
        }

        /// <summary>
        /// Insert the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        public bool InsertTeamMember(TeamMember teamMember)
        {
            if (teamMember == null) { throw new ArgumentNullException("teamMember is null"); }

            bool result = _teamMemberRepository.Insert(teamMember);

            return result;
        }

        /// <summary>
        /// Updates the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        public bool UpdateTeamMember(TeamMember teamMember)
        {
            if (teamMember == null) { throw new ArgumentNullException("teamMember is null"); }

            bool result = _teamMemberRepository.SingleUpdate(teamMember);

            return result;
        }

        /// <summary>
        /// Delete the TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        /// <returns></returns>
        public bool DeleteTeamMember(TeamMember teamMember)
        {
            if (teamMember == null) { throw new ArgumentNullException("teamMember is null"); }

            bool result = _teamMemberRepository.Delete(teamMember);

            return result;
        }

    }
}
