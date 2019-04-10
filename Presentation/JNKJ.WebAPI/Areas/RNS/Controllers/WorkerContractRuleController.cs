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
    public class WorkerContractRuleController : BaseController
    {
        #region Fields

        private readonly IWorkerContractRule _workerContractRule;

        #endregion

        #region Ctor

        public WorkerContractRuleController(IWorkerContractRule workerContractRule)
        {
            _workerContractRule = workerContractRule;
        }

        #endregion

        [HttpGet]
        [ActionName("get__workerContractRules")]
        public HttpResponseMessage GetWorkerContractRules([FromUri]WorkerContractRuleRequest request)
        {
            var result = _workerContractRule.GetWorkerContractRules(request.startDate, request.endDate, request.projectCode,request.organizationCode,request.iDCardNumber,request.contractCode, request.pageIndex, request.pageSize);

            var list = new PageList<WorkerContractRule>()
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
        [ActionName("get_workerContractRule_by_id")]
        public HttpResponseMessage GetWorkerContractRuleById([FromUri]Guid workerContractRuleId)
        {
            var result = _workerContractRule.GetWorkerContractRuleById(workerContractRuleId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_workerContractRule_by_projectCode")]
        public HttpResponseMessage GetWorkerContractRuleByProjectCode([FromUri]string projectCode)
        {
            var result = _workerContractRule.GetWorkerContractRuleByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_workerContractRule")]
        public HttpResponseMessage DeleteWorkerContractRule([FromBody]Guid workerContractRuleId)
        {
            var obj = _workerContractRule.GetWorkerContractRuleById(workerContractRuleId);

            var result = _workerContractRule.DeleteWorkerContractRule(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_workerContractRule")]
        public HttpResponseMessage InsertWorkerContractRule(WorkerContractRule workerContractRule)
        {
            var newObj = new WorkerContractRule()
            {
                Id = Guid.NewGuid(),
                ProjectCode = workerContractRule.ProjectCode,
                OrganizationCode =workerContractRule.OrganizationCode,
                IDCardType = workerContractRule.IDCardType,
                IDCardNumber = workerContractRule.IDCardNumber,
                ContractCode = workerContractRule.ContractCode,
                ContractPeriodType = workerContractRule.ContractPeriodType,
                StartDate = workerContractRule.StartDate,
                EndDate = workerContractRule.EndDate,
                PayRollRuleType = workerContractRule.PayRollRuleType,
                UnitTypeSysNo = workerContractRule.UnitTypeSysNo,
                UnitPrice = workerContractRule.UnitPrice
            };
            var result = _workerContractRule.InsertWorkerContractRule(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_workerContractRule")]
        public HttpResponseMessage UpdateWorkerContractRule(WorkerContractRule workerContractRule)
        {
            if (workerContractRule.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var result = _workerContractRule.UpdateWorkerContractRule(workerContractRule);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
