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
    public class PayRollController : BaseController
    {
        #region Fields

        private readonly IPayRoll _payRoll;

        #endregion

        #region Ctor

        public PayRollController(IPayRoll payRoll)
        {
            _payRoll = payRoll;
        }

        #endregion

        [HttpGet]
        [ActionName("get_payRolls")]
        public HttpResponseMessage GetPayRolls([FromUri]PayRollRequest request)
        {
            var result = _payRoll.GetPayRolls(request.payMonth,request.payRollCode, request.projectCode, request.organizationCode,request.teamSysNo, request.status, request.pageIndex,
                request.pageSize);

            var list = new PageList<PayRoll>()
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
        [ActionName("get_payRolls_by_id")]
        public HttpResponseMessage GetPayRollIdById([FromUri]Guid payRollId)
        {
            var result = _payRoll.GetPayRollById(payRollId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_payRollId")]
        public HttpResponseMessage DeletePayRoll([FromBody]Guid payRollId)
        {
            var obj = _payRoll.GetPayRollById(payRollId);

            var result = _payRoll.DeletePayRoll(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_payRoll")]
        public HttpResponseMessage InsertPayRoll(PayRoll payRoll)
        {
            var newObj = new PayRoll()
            {
                Id = Guid.NewGuid(),
                ProjectCode = payRoll.ProjectCode,
                PayRollCode = payRoll.PayRollCode,
                OrganizationCode = payRoll.OrganizationCode,
                TeamSysNo = payRoll.TeamSysNo,
                PayMonth = payRoll.PayMonth,
                Status = payRoll.Status,
                ContractorProjectCode = payRoll.ContractorProjectCode,
                SubContractorProjectCode = payRoll.SubContractorProjectCode,
                AttachFiles = payRoll.AttachFiles
            };
            var result = _payRoll.InsertPayRoll(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_payRoll")]
        public HttpResponseMessage UpdatePayRoll(PayRoll payRoll)
        {
            if (payRoll.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "修改失败");
            }
            var obj = _payRoll.GetPayRollById(payRoll.Id);
            payRoll.PayMonth = obj.PayMonth;
            var result = _payRoll.UpdatePayRoll(payRoll);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
