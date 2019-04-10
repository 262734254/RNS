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
    public class PersonalCertificationsController : BaseController
    {
        #region Fields

        private readonly IPersonalCertifications _personalCertificationsService;

        #endregion

        #region Ctor

        public PersonalCertificationsController(IPersonalCertifications personalCertificationsService)
        {
            _personalCertificationsService = personalCertificationsService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_personalcertificationss")]
        public HttpResponseMessage GetPersonalCertificationss([FromUri]PersonalCertificationsRequest request)
        {
            var result = _personalCertificationsService.GetPersonalCertificationss(request.issueDate, request.iDCardNumber, request.professionCode, request.jobType, request.status, request.pageIndex,request.pageSize);

            var list = new PageList<PersonalCertifications>()
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
        [ActionName("get_personalcertifications_by_id")]
        public HttpResponseMessage GetPersonalCertificationsById([FromUri]Guid personalCertificationsId)
        {
            var result = _personalCertificationsService.GetPersonalCertificationsById(personalCertificationsId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_personalcertifications")]
        public HttpResponseMessage DeletePersonalCertifications([FromBody]Guid personalCertificationsId)
        {
            var obj = _personalCertificationsService.GetPersonalCertificationsById(personalCertificationsId);

            var result = _personalCertificationsService.DeletePersonalCertifications(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_personalcertifications")]
        public HttpResponseMessage InsertPersonalCertifications(PersonalCertifications personalCertifications)
        {
            personalCertifications.Id = Guid.NewGuid();

            var result = _personalCertificationsService.InsertPersonalCertifications(personalCertifications);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_personalcertifications")]
        public HttpResponseMessage UpdatePersonalCertifications(PersonalCertifications personalCertifications)
        {
            var result = _personalCertificationsService.UpdatePersonalCertifications(personalCertifications);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
