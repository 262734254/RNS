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
    public class WorkerBadRecordsController : BaseController
    {
        #region Fields

        private readonly IWorkerBadRecords _workerBadRecordsService;

        #endregion

        #region Ctor

        public WorkerBadRecordsController(IWorkerBadRecords workerBadRecordsService)
        {
            _workerBadRecordsService = workerBadRecordsService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_workerbadrecordss")]
        public HttpResponseMessage GetWorkerBadRecordss([FromUri]WorkerBadRecordsRequest request)
        {
            var result = _workerBadRecordsService.GetWorkerBadRecordss(request.occurrenceDate, request.projectCode, request.organizationCode, request.iDCardNumber, request.pageIndex,
                request.pageSize);

            var list = new PageList<WorkerBadRecords>()
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
        [ActionName("get_workerbadrecords_by_id")]
        public HttpResponseMessage GetWorkerBadRecordsById([FromUri]Guid workerBadRecordsId)
        {
            var result = _workerBadRecordsService.GetWorkerBadRecordsById(workerBadRecordsId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_workerbadrecords")]
        public HttpResponseMessage DeleteWorkerBadRecords([FromBody]Guid workerBadRecordsId)
        {
            var obj = _workerBadRecordsService.GetWorkerBadRecordsById(workerBadRecordsId);

            var result = _workerBadRecordsService.DeleteWorkerBadRecords(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workerbadrecords")]
        public HttpResponseMessage InsertWorkerBadRecords(WorkerBadRecords workerBadRecords)
        {
            workerBadRecords.Id = Guid.NewGuid();

            var result = _workerBadRecordsService.InsertWorkerBadRecords(workerBadRecords);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workerbadrecords")]
        public HttpResponseMessage UpdateWorkerBadRecords(WorkerBadRecords workerBadRecords)
        {
            var result = _workerBadRecordsService.UpdateWorkerBadRecords(workerBadRecords);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}

