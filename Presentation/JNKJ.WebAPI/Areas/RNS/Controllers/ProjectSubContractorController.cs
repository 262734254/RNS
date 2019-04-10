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
    public class ProjectSubContractorController :BaseController
    {
        #region Fields

        private readonly IProjectSubContractor _projectSubContractor;

        #endregion

        #region Ctor

        public ProjectSubContractorController(IProjectSubContractor projectSubContractor)
        {
            _projectSubContractor = projectSubContractor;
        }

        #endregion

        [HttpGet]
        [ActionName("get_projectSubContractors")]
        public HttpResponseMessage GetProjectSubContractors([FromUri]ProjectSubContractorRequest request)
        {
            var result = _projectSubContractor.GetProjectSubContractors(request.entryTime, request.exitTime, request.projectCode, request.organizationCode, request.contractorType, request.pageIndex,
                request.pageSize);

            var list = new PageList<ProjectSubContractor>()
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
        [ActionName("get_projectSubContractors_by_id")]
        public HttpResponseMessage GetProjectSubContractorById([FromUri]Guid projectSubContractorId)
        {
            var result = _projectSubContractor.GetProjectSubContractorById(projectSubContractorId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_projectSubContractors_by_projectCode")]
        public HttpResponseMessage GetProjectSubContractorByProjectCode([FromUri]string projectCode)
        {
            var result = _projectSubContractor.GetProjectSubContractorByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpPost]
        [ActionName("delete_projectSubContractor")]
        public HttpResponseMessage DeleteProjectSubContractor([FromBody]Guid projectSubContractorId)
        {
            var obj = _projectSubContractor.GetProjectSubContractorById(projectSubContractorId);

            var result = _projectSubContractor.DeleteProjectSubContractor(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_projectSubContractor")]
        public HttpResponseMessage InsertProjectSubContractor(ProjectSubContractor projectSubContractor)
        {
            var newObj = new ProjectSubContractor()
            {
                Id = Guid.NewGuid(),
                ProjectCode = projectSubContractor.ProjectCode,
                OrganizationCode = projectSubContractor.OrganizationCode,
                ContractorType = projectSubContractor.ContractorType,
                EntryTime = projectSubContractor.EntryTime,
                ExitTime = projectSubContractor.ExitTime,
                BankName = projectSubContractor.BankName,
                BankNumber = projectSubContractor.BankNumber,
                BankLinkNumber = projectSubContractor.BankLinkNumber,
                PayMode = projectSubContractor.PayMode,
                PMName = projectSubContractor.PMName,
                PMIDCardType = projectSubContractor.PMIDCardType,
                PMIDCardNumber = projectSubContractor.PMIDCardNumber,
                PMPhone = projectSubContractor.PMPhone
            };
            var result = _projectSubContractor.InsertProjectSubContractor(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_projectSubContractor")]
        public HttpResponseMessage UpdateProjectSubContractor(ProjectSubContractor projectSubContractor)
        {
            if (projectSubContractor.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var obj = _projectSubContractor.GetProjectSubContractorById(projectSubContractor.Id);

            if (projectSubContractor.OrganizationCode == null)
            {
                projectSubContractor.OrganizationCode = obj.OrganizationCode;
            }
            if (projectSubContractor.ContractorType == null)
            {
                projectSubContractor.ContractorType = obj.ContractorType;
            }
            
            var result = _projectSubContractor.UpdateProjectSubContractor(projectSubContractor);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
