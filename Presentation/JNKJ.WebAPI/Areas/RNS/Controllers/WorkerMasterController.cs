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
    public class WorkerMasterController : BaseController
    {
        #region Fields

        private readonly IWorkerMaster _workerMasterService;

        #endregion

        #region Ctor

        public WorkerMasterController(IWorkerMaster workerMasterService)
        {
            _workerMasterService = workerMasterService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_workermasters")]
        public HttpResponseMessage GetWorkerMasters([FromUri]WorkerMasterRequest request)
        {
            var result = _workerMasterService.GetWorkerMasters(request.joinedTime, request.workerName, request.iDCardNumber, request.cellPhone, request.pageIndex,
                request.pageSize);

            var list = new PageList<WorkerMasterResponse>()
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
        [ActionName("get_workermaster_by_id")]
        public HttpResponseMessage GetWorkerMasterById([FromUri]Guid workerMasterId)
        {
            var result = _workerMasterService.GetWorkerMasterById(workerMasterId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_workermaster")]
        public HttpResponseMessage DeleteWorkerMaster([FromBody]Guid workerMasterId)
        {
            var obj = _workerMasterService.GetWorkerMasterById(workerMasterId);

            var result = _workerMasterService.DeleteWorkerMaster(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workermaster")]
        public HttpResponseMessage InsertWorkerMaster(WorkerMasterResponse workerMaster)
        {
            workerMaster.Id = Guid.NewGuid();

            var result = _workerMasterService.InsertWorkerMaster(workerMaster);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workermaster")]
        public HttpResponseMessage UpdateWorkerMaster(WorkerMaster workerMaster)
        {
            var result = _workerMasterService.UpdateWorkerMaster(workerMaster);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
