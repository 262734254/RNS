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
    public class TeamMasterController : BaseController
    {
        #region Fields

        private readonly ITeamMaster _teamMasterService;

        #endregion

        #region Ctor

        public TeamMasterController(ITeamMaster teamMasterService)
        {
            _teamMasterService = teamMasterService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_teammasters")]
        public HttpResponseMessage GetTeamMasters([FromUri]TeamMasterRequest request)
        {
            var result = _teamMasterService.GetTeamMasters(request.teamSysNo, request.projectCode, request.organizationCode, request.teamName, request.contact, request.pageIndex,
                request.pageSize);

            var list = new PageList<TeamMaster>()
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
        [ActionName("get_teammaster_by_id")]
        public HttpResponseMessage GetTeamMasterById([FromUri]Guid teamMasterId)
        {
            var result = _teamMasterService.GetTeamMasterById(teamMasterId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_teammaster")]
        public HttpResponseMessage DeleteTeamMaster([FromBody]Guid teamMasterId)
        {
            var obj = _teamMasterService.GetTeamMasterById(teamMasterId);

            var result = _teamMasterService.DeleteTeamMaster(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_teammaster")]
        public HttpResponseMessage InsertTeamMaster(TeamMaster teamMaster)
        {
            var newObj = new TeamMaster()
            {
                Id = Guid.NewGuid(),
                Contact = teamMaster.Contact,
                Note = teamMaster.Note,
                OrganizationCode = teamMaster.OrganizationCode,
                ProjectCode = teamMaster.ProjectCode,
                ResponsiblePersonIDNumber = teamMaster.ResponsiblePersonIDNumber,
                TeamLeader = teamMaster.TeamLeader,
                TeamLeaderIDNumber = teamMaster.TeamLeaderIDNumber,
                TeamName = teamMaster.TeamName,
                TeamSysNo = teamMaster.TeamSysNo
            };
            var result = _teamMasterService.InsertTeamMaster(newObj);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_teammaster")]
        public HttpResponseMessage UpdateTeamMaster(TeamMaster teamMaster)
        {
            //先读取对象到上下文中，再更新
            //var newObj = _teamMasterService.GetTeamMasterById(teamMaster.Id);
            //newObj.TeamName = teamMaster.TeamName;
            //var result = _teamMasterService.UpdateTeamMaster(newObj);


            //直接用SingleUpdate更新单个对象
            var result = _teamMasterService.UpdateTeamMaster(teamMaster);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
