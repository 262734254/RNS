using JNKJ.Core.Data;
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
    public class PayRollDetailController : BaseController
    {
        #region Fields

        private readonly IPayRollDetail _payRollDetailService;

        #endregion

        #region Ctor

        public PayRollDetailController(IPayRollDetail payRollDetailService)
        {
            _payRollDetailService = payRollDetailService;
        }

        #endregion

        [HttpGet]
        [ActionName("get_payRollDetails")]
        public HttpResponseMessage GetPayRollDetails([FromUri]PayRollDetailRequest request)
        {
            var result = _payRollDetailService.GetPayRollDetails(request.balanceDate, request.payRollCode,request.iDCardNumber, request.payRollBankCardNumber,request.payStatus, request.pageIndex,
                request.pageSize);

            var list = new PageList<PayRollDetail>()
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
        [ActionName("get_payRollDetails_by_id")]
        public HttpResponseMessage GetPayRollDetailById([FromUri]Guid payRollDetailId)
        {
            var result = _payRollDetailService.GetPayRollDetailById(payRollDetailId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_payRollDetai")]
        public HttpResponseMessage DeletePayRollDetail([FromBody]Guid payRollDetailId)
        {
            var obj = _payRollDetailService.GetPayRollDetailById(payRollDetailId);

            var result = _payRollDetailService.DeletePayRollDetail(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_payRollDetai")]
        public HttpResponseMessage InsertPayRollDetail(PayRollDetail payRollDetail)
        {
            var newObj = new PayRollDetail()
            {
                Id = Guid.NewGuid(),
                PayRollCode = payRollDetail.PayRollCode,
                IDCardType = payRollDetail.IDCardType,
                IDCardNumber = payRollDetail.IDCardNumber,
                WorkerType = payRollDetail.WorkerType,
                TotalPayAmount = payRollDetail.TotalPayAmount,
                ActualAmount = payRollDetail.ActualAmount,
                Days = payRollDetail.Days,
                WorkHours =payRollDetail.WorkHours,
                BalanceDate = payRollDetail.BalanceDate,
                PayRollBankCardNumber = payRollDetail.PayRollBankCardNumber,
                PayRollBankName = payRollDetail.PayRollBankName,
                PayRollBankCode = payRollDetail.PayRollBankCode,
                PayTotalAmount = payRollDetail.PayTotalAmount,
                PayStatus = payRollDetail.PayStatus,
                SettleTotalAmount = payRollDetail.SettleTotalAmount
            };
            var result = _payRollDetailService.InsertPayRollDetail(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_payRollDetai")]
        public HttpResponseMessage UpdatePayRollDetai(PayRollDetail payRollDetai)
        {
            if (payRollDetai.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }
            var obj = _payRollDetailService.GetPayRollDetailById(payRollDetai.Id);
            payRollDetai.BalanceDate = obj.BalanceDate;
            var result = _payRollDetailService.UpdatePayRollDetail(payRollDetai);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
