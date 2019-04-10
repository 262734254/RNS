using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.Enums;
using JNKJ.Dto.RealNameSystem;
using JNKJ.Dto.Results;
using JNKJ.Dto.ViewModel;
using JNKJ.Services.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class WorkerAttendanceController : BaseController
    {
        #region Fields

        private readonly IWorkerAttendance _workerAttendance;

        #endregion

        #region Ctor

        public WorkerAttendanceController(IWorkerAttendance workerAttendance)
        {
            _workerAttendance = workerAttendance;
        }

        #endregion

        [HttpGet]
        [ActionName("get_workerAttendances")]
        public HttpResponseMessage GetWorkerAttendances([FromUri]WorkerAttendanceRequest request)
        {
            var result = _workerAttendance.GetWorkerAttendances(request.checkTime, request.projectCode, request.iDCardNumber,request.pageIndex, request.pageSize);

            var list = new PageList<WorkerAttendanceViewModel>()
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
        [ActionName("get_workerAttendance_by_id")]
        public HttpResponseMessage GetWorkerAttendanceById([FromUri]Guid workerAttendanceId)
        {
            var result = _workerAttendance.GetWorkerAttendanceById(workerAttendanceId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_workerAttendance_by_projectCode")]
        public HttpResponseMessage GetWorkerAttendanceByProjectCode([FromUri]string projectCode)
        {
            var result = _workerAttendance.GetWorkerAttendanceByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpPost]
        [ActionName("delete_workerAttendance")]
        public HttpResponseMessage DeleteWorkerAttendanceId([FromBody]Guid workerAttendanceId)
        {
            var obj = _workerAttendance.GetWorkerAttendanceById(workerAttendanceId);

            var result = _workerAttendance.DeleteWorkerAttendance(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workerAttendance")]
        public HttpResponseMessage InsertWorkerAttendance(WorkerAttendance workerAttendance)
        {
            var newObj = new WorkerAttendance()
            {
                Id = Guid.NewGuid(),
                ProjectCode = workerAttendance.ProjectCode,
                IDCardType = workerAttendance.IDCardType,
                IDCardNumber = workerAttendance.IDCardNumber,
                CheckTime = workerAttendance.CheckTime,
                CheckType = workerAttendance.CheckType,
                CheckChannel = workerAttendance.CheckChannel,
                DataResource = workerAttendance.DataResource

            };
            var result = _workerAttendance.InsertWorkerAttendance(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workerAttendance")]
        public HttpResponseMessage UpdateWorkerAttendance(WorkerAttendance workerAttendance)
        {
            if (workerAttendance.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var result = _workerAttendance.UpdateWorkerAttendance(workerAttendance);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
