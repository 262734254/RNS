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
    public class WorkerGoodRecordsController : BaseController
    {
        #region Fields

        private readonly IWorkerGoodRecords _workerGoodRecordsService;

        #endregion

        #region Ctor

        public WorkerGoodRecordsController(IWorkerGoodRecords workerGoodRecordsService)
        {
            _workerGoodRecordsService = workerGoodRecordsService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_workergoodrecordss")]
        public HttpResponseMessage GetWorkerGoodRecordss([FromUri]WorkerGoodRecordsRequest request)
        {
            var result = _workerGoodRecordsService.GetWorkerGoodRecordss(request.occurrenceDate, request.projectCode, request.organizationCode, request.iDCardNumber, request.pageIndex,
                request.pageSize);

            var list = new PageList<WorkerGoodRecords>()
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
        [ActionName("get_workergoodrecords_by_id")]
        public HttpResponseMessage GetWorkerGoodRecordsById([FromUri]Guid workerGoodRecordsId)
        {
            var result = _workerGoodRecordsService.GetWorkerGoodRecordsById(workerGoodRecordsId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_workergoodrecords")]
        public HttpResponseMessage DeleteWorkerGoodRecords([FromBody]Guid workerGoodRecordsId)
        {
            var obj = _workerGoodRecordsService.GetWorkerGoodRecordsById(workerGoodRecordsId);

            var result = _workerGoodRecordsService.DeleteWorkerGoodRecords(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workergoodrecords")]
        public HttpResponseMessage InsertWorkerGoodRecords(WorkerGoodRecords workerGoodRecords)
        {
            workerGoodRecords.Id = Guid.NewGuid();

            var result = _workerGoodRecordsService.InsertWorkerGoodRecords(workerGoodRecords);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workergoodrecords")]
        public HttpResponseMessage UpdateWorkerGoodRecords(WorkerGoodRecords workerGoodRecords)
        {
            var result = _workerGoodRecordsService.UpdateWorkerGoodRecords(workerGoodRecords);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
