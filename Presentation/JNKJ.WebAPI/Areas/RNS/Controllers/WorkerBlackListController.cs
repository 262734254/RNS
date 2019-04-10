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
    public class WorkerBlackListController : BaseController
    {
        #region Fields

        private readonly IWorkerBlackList _workerBlackListService;

        #endregion

        #region Ctor

        public WorkerBlackListController(IWorkerBlackList workerBlackListService)
        {
            _workerBlackListService = workerBlackListService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_workerblacklists")]
        public HttpResponseMessage GetWorkerBlackLists([FromUri]WorkerBlackListRequest request)
        {
            var result = _workerBlackListService.GetWorkerBlackLists(request.projectCode, request.organizationCode, request.iDCardNumber, request.teamSysNo, request.teamName, request.pageIndex,
                request.pageSize);

            var list = new PageList<WorkerBlackList>()
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
        [ActionName("get_workerblacklist_by_id")]
        public HttpResponseMessage GetWorkerBlackListById([FromUri]Guid workerBlackListId)
        {
            var result = _workerBlackListService.GetWorkerBlackListById(workerBlackListId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_workerblacklist")]
        public HttpResponseMessage DeleteWorkerBlackList([FromBody]Guid workerBlackListId)
        {
            var obj = _workerBlackListService.GetWorkerBlackListById(workerBlackListId);

            var result = _workerBlackListService.DeleteWorkerBlackList(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workerblacklist")]
        public HttpResponseMessage InsertWorkerBlackList(WorkerBlackList workerBlackList)
        {
            workerBlackList.Id = Guid.NewGuid();

            var result = _workerBlackListService.InsertWorkerBlackList(workerBlackList);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workerblacklist")]
        public HttpResponseMessage UpdateWorkerBlackList(WorkerBlackList workerBlackList)
        {
            var result = _workerBlackListService.UpdateWorkerBlackList(workerBlackList);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
