using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.Enums;
using JNKJ.Dto.RealNameSystem;
using JNKJ.Dto.Results;
using JNKJ.Services.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class EntryExitHistoryController : BaseController
    {
        #region Fields

        private readonly IEntryExitHistory _entryExitHistoryService;

        #endregion

        #region Ctor

        public EntryExitHistoryController(IEntryExitHistory entryExitHistoryService)
        {
            _entryExitHistoryService = entryExitHistoryService;
        }

        #endregion

        [HttpGet]
        [ActionName("get_entryExitHistorys")]
        public HttpResponseMessage GetTeamMasters([FromUri]EntryExitHistoryRequest request)
        {
            var result = _entryExitHistoryService.GetEntryExitHistorys(request.projectCode, request.organizationCode, request.iDCardNumber, request.type, request.pageIndex,
                request.pageSize);

            var list = new PageList<EntryExitHistory>()
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
        [ActionName("get_entryExitHistorys_by_id")]
        public HttpResponseMessage GetEntryExitHistoryById([FromUri]Guid entryExitHistoryId)
        {
            var result = _entryExitHistoryService.GetEntryExitHistoryById(entryExitHistoryId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_entryExitHistorys_by_projectCode")]
        public HttpResponseMessage GetEntryExitHistorysByProjectCode([FromUri]string projectCode)
        {
            var result = _entryExitHistoryService.GetEntryExitHistorysByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_entryExitHistory")]
        public HttpResponseMessage DeleteTeamMaster([FromBody]Guid entryExitHistoryId)
        {
            var obj = _entryExitHistoryService.GetEntryExitHistoryById(entryExitHistoryId);

            var result = _entryExitHistoryService.DeleteEntryExitHistory(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_entryExitHistory")]
        public HttpResponseMessage InsertEntryExitHistory(EntryExitHistory entryExitHistory)
        {
            var newObj = new EntryExitHistory()
            {
                Id = Guid.NewGuid(),
                ProjectCode = entryExitHistory.ProjectCode,
                OrganizationCode = entryExitHistory.OrganizationCode,
                IDCardType = entryExitHistory.IDCardNumber,
                IDCardNumber = entryExitHistory.IDCardNumber,
                Type = entryExitHistory.Type,
                Date = DateTime.Now
            };
            var result = _entryExitHistoryService.InsertEntryExitHistory(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_entryExitHistory")]
        public HttpResponseMessage UpdateTeamMaster(EntryExitHistory entryExitHistory)
        {
            var result = _entryExitHistoryService.UpdateEntryExitHistory(entryExitHistory);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
