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
    public class TeamReviewController : BaseController
    {
        #region Fields

        private readonly ITeamReview _teamReviewService;

        #endregion

        #region Ctor

        public TeamReviewController(ITeamReview teamReviewService)
        {
            _teamReviewService = teamReviewService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_teamreviews")]
        public HttpResponseMessage GetTeamReviews([FromUri]TeamReviewRequest request)
        {
            var result = _teamReviewService.GetTeamReviews(request.projectCode, request.organizationCode, request.teamSysNo, request.pageIndex, request.pageSize);

            var list = new PageList<TeamReview>()
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
        [ActionName("get_teamreview_by_id")]
        public HttpResponseMessage GetTeamReviewById([FromUri]Guid teamReviewId)
        {
            var result = _teamReviewService.GetTeamReviewById(teamReviewId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_teamreview")]
        public HttpResponseMessage DeleteTeamReview([FromBody]Guid teamReviewId)
        {
            var obj = _teamReviewService.GetTeamReviewById(teamReviewId);

            var result = _teamReviewService.DeleteTeamReview(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_teamreview")]
        public HttpResponseMessage InsertTeamReview(TeamReview teamReview)
        {
            teamReview.Id = Guid.NewGuid();

            var result = _teamReviewService.InsertTeamReview(teamReview);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_teamreview")]
        public HttpResponseMessage UpdateTeamReview(TeamReview teamReview)
        {
            var result = _teamReviewService.UpdateTeamReview(teamReview);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
