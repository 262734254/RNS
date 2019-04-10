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
    public class SubContractorBlackListBlackListController : BaseController
    {
        #region Fields

        private readonly ISubContractorBlackList _subContractorBlackListService;

        #endregion

        #region Ctor

        public SubContractorBlackListBlackListController(ISubContractorBlackList subContractorBlackListService)
        {
            _subContractorBlackListService = subContractorBlackListService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_subcontractorblacklists")]
        public HttpResponseMessage GetSubContractorBlackLists([FromUri]SubContractorBlackListRequest request)
        {
            var result = _subContractorBlackListService.GetSubContractorBlackLists(request.organizationCode, request.pageIndex, request.pageSize);

            var list = new PageList<SubContractorBlackList>()
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
        [ActionName("get_subcontractorblacklist_by_id")]
        public HttpResponseMessage GetSubContractorBlackListById([FromUri]Guid subContractorBlackListId)
        {
            var result = _subContractorBlackListService.GetSubContractorById(subContractorBlackListId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_subcontractorblacklist")]
        public HttpResponseMessage DeleteSubContractorBlackList(Guid subContractorBlackListId)
        {
            var obj = _subContractorBlackListService.GetSubContractorById(subContractorBlackListId);

            var result = _subContractorBlackListService.DeleteSubContractorBlackList(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_subcontractorblacklist")]
        public HttpResponseMessage InsertSubContractorBlackList(SubContractorBlackList subContractorBlackList)
        {
            var obj = _subContractorBlackListService.GetSubContractorByOrganizationCode(subContractorBlackList.OrganizationCode);
            if (obj != null)
            {
                _subContractorBlackListService.DeleteSubContractorBlackList(obj);
            }
            subContractorBlackList.Id = Guid.NewGuid();

            var result = _subContractorBlackListService.InsertSubContractorBlackList(subContractorBlackList);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_subcontractorblacklist")]
        public HttpResponseMessage UpdateSubContractorBlackList(SubContractorBlackList subContractorBlackList)
        {
            var result = _subContractorBlackListService.UpdateSubContractorBlackList(subContractorBlackList);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }


        [HttpGet]
        [ActionName("get_subcontractorblacklist_by_organizationcode")]
        public HttpResponseMessage GetSubContractorByOrganizationCode([FromUri]string organizationCode)
        {
            var result = _subContractorBlackListService.GetSubContractorByOrganizationCode(organizationCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }


    }
}
