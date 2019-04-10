using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.RealNameSystem;
using JNKJ.Dto.Results;
using JNKJ.Services.RealNameSystem;
using System.Net.Http;
using System.Web.Http;

using System.Linq;
using JNKJ.Dto.Enums;
using System;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class TeamMemberController : BaseController
    {
        #region Fields

        private readonly ITeamMember _teamMemberService;

        #endregion

        #region Ctor

        public TeamMemberController(ITeamMember teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_teammembers")]
        public HttpResponseMessage GetTeamMembers([FromUri]TeamMemberRequest request)
        {
            var result = _teamMemberService.GetTeamMembers(request.teamSysNo, request.iDCardNumber, request.pageIndex, request.pageSize);

            var list = new PageList<TeamMember>()
            {
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages,
                Data = result.ToList()
            };
            return toListJson(list, OperatingState.Success, "获取成功");
        }



        [HttpGet]
        [ActionName("get_teammember_by_id")]
        public HttpResponseMessage GetTeamMemberById([FromUri]Guid teamMemberId)
        {
            var result = _teamMemberService.GetTeamMemberById(teamMemberId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_teammember")]
        public HttpResponseMessage DeleteTeamMember([FromBody]Guid teamMemberId)
        {
            var obj = _teamMemberService.GetTeamMemberById(teamMemberId);

            var result = _teamMemberService.DeleteTeamMember(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_teammember")]
        public HttpResponseMessage InsertTeamMember(TeamMember teamMember)
        {
            teamMember.Id = Guid.NewGuid();

            var result = _teamMemberService.InsertTeamMember(teamMember);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_teammember")]
        public HttpResponseMessage UpdateTeamMember(TeamMember teamMember)
        {
            var result = _teamMemberService.UpdateTeamMember(teamMember);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
