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
    public class SubContractorCertificationsController : BaseController
    {
        #region Fields

        private readonly ISubContractorCertifications _subContractorCertificationsService;

        #endregion

        #region Ctor

        public SubContractorCertificationsController(ISubContractorCertifications subContractorCertificationsService)
        {
            _subContractorCertificationsService = subContractorCertificationsService;
        }

        #endregion

        [HttpGet]
        [ActionName("get_subcontractorcertificationss")]
        public HttpResponseMessage GetSubContractorCertificationss([FromUri]SubContractorCertificationsRequest request)
        {
            var result = _subContractorCertificationsService.GetSubContractorCertificationss(request.certificationName, request.organizationCode, request.qualificationStatus, request.pageIndex,
                request.pageSize);

            var list = new PageList<SubContractorCertifications>()
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
        [ActionName("get_subcontractorcertifications_by_id")]
        public HttpResponseMessage GetSubContractorCertificationsById([FromUri]Guid subContractorCertificationsId)
        {
            var result = _subContractorCertificationsService.GetSubContractorCertificationsById(subContractorCertificationsId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_subcontractorcertifications")]
        public HttpResponseMessage DeleteSubContractorCertifications(Guid subContractorCertificationsId)
        {
            var obj = _subContractorCertificationsService.GetSubContractorCertificationsById(subContractorCertificationsId);

            var result = _subContractorCertificationsService.DeleteSubContractorCertifications(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_subcontractorcertifications")]
        public HttpResponseMessage InsertSubContractorCertifications(SubContractorCertifications subContractorCertifications)
        {
            var obj = _subContractorCertificationsService.GetSubContractorCertificationsByOrganizationCode(subContractorCertifications.OrganizationCode);
            if (obj != null)
            {
                _subContractorCertificationsService.DeleteSubContractorCertifications(obj);
            }
            subContractorCertifications.Id = Guid.NewGuid();
            var result = _subContractorCertificationsService.InsertSubContractorCertifications(subContractorCertifications);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_subcontractorcertifications")]
        public HttpResponseMessage UpdateSubContractorCertifications(SubContractorCertifications subContractorCertifications)
        {
            var result = _subContractorCertificationsService.UpdateSubContractorCertifications(subContractorCertifications);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }



        [HttpGet]
        [ActionName("get_subcontractorcertifications_by_organizationcode")]
        public HttpResponseMessage GetSubContractorCertificationsByOrganizationCode(string organizationCode)
        {
            var result = _subContractorCertificationsService.GetSubContractorCertificationsByOrganizationCode(organizationCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }



    }
}
