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
    public class SubContractorController : BaseController
    {
        #region Fields

        private readonly ISubContractor _subContractorService;
        private readonly IUser _userService;


        #endregion

        #region Ctor

        public SubContractorController(ISubContractor subContractorService, IUser userService)
        {
            _subContractorService = subContractorService;
            _userService = userService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_subcontractors")]
        public HttpResponseMessage GetSubContractors([FromUri]SubContractorRequest request)
        {
            var result = _subContractorService.GetSubContractors(request.isAdmin, request.subContractorId, request.establishDate, request.companyName, request.organizationCode, request.businessStatus, request.pageIndex, request.pageSize);

            var list = new PageList<SubContractor>()
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
        [ActionName("get_subcontractor_by_id")]
        public HttpResponseMessage GetSubContractorById([FromUri]Guid subContractorId)
        {
            var result = _subContractorService.GetSubContractorById(subContractorId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_subcontractor")]
        public HttpResponseMessage DeleteSubContractor([FromBody]Guid subContractorId)
        {
            var obj = _subContractorService.GetSubContractorById(subContractorId);

            var result = _subContractorService.DeleteSubContractor(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_subcontractor")]
        public HttpResponseMessage InsertSubContractor(SubContractor subContractor)
        {
            subContractor.Id = Guid.NewGuid();

            var result = _subContractorService.InsertSubContractor(subContractor);

            if (result)
            {
                //添加企业同步添加对应的用户
                var userResult = _userService.InsertUser(new User()
                {
                    Id = Guid.NewGuid(),
                    IsAdmin = false,
                    Password = "123456",
                    SubContractorId = subContractor.Id,
                    UserName = subContractor.ContactPeopleCellPhone,
                    UserImgUrl = ""
                });
                return userResult ? toJson(null, OperatingState.Success, "企业添加成功，已同步生成系统账号") : toJson(null, OperatingState.Failure, "企业添加成功，同步生成系统账号失败");
            }

            return toJson(null, OperatingState.Failure, "企业添加失败");
        }



        [HttpPost]
        [ActionName("update_subcontractor")]
        public HttpResponseMessage UpdateSubContractor(SubContractor subContractor)
        {
            var result = _subContractorService.UpdateSubContractor(subContractor);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
