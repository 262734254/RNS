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
    public class ProjectMasterController : BaseController
    {
        #region Fields

        private readonly IProjectMaster _projectMaster;

        #endregion

        #region Ctor

        public ProjectMasterController(IProjectMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }

        #endregion

        [HttpGet]
        [ActionName("get_projectMasters")]
        public HttpResponseMessage GetProjectMasters([FromUri]ProjectMasterRequest request)
        {
            var result = _projectMaster.GetProjectMasters(request.isAdmin,request.startDate, request.completeDate, request.SubContractorId, request.projectCode, request.projectName, request.projectStatus,  request.pageIndex,
                request.pageSize);

            var list = new PageList<ProjectMaster>()
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
        [ActionName("get_projectMasters_by_id")]
        public HttpResponseMessage GetProjectMasterById([FromUri]Guid projectMasterId)
        {
            var result = _projectMaster.GetProjectMasterById(projectMasterId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_projectMaster")]
        public HttpResponseMessage DeleteProjectMaster([FromBody]Guid projectMasterId)
        {
            var obj = _projectMaster.GetProjectMasterById(projectMasterId);

            var result = _projectMaster.DeleteProjectMaster(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_projectMaster")]
        public HttpResponseMessage InsertProjectMaster(ProjectMaster projectMaster)
        {
            var newObj = new ProjectMaster()
            {
                Id = Guid.NewGuid(),
                ProjectCode = projectMaster.ProjectCode,
                BuildProjectCode = projectMaster.BuildProjectCode,
                ContractorOrgCode = projectMaster.ContractorOrgCode,
                GeneralContractorCode = projectMaster.GeneralContractorCode,
                GeneralContractorName = projectMaster.GeneralContractorName,
                ProjectName = projectMaster.ProjectName,
                ProjectActivityType = projectMaster.ProjectActivityType,
                ProjectDescription = projectMaster.ProjectDescription,
                ProjectCategory = projectMaster.ProjectCategory,
                IsMajorProject = projectMaster.IsMajorProject,
                OwnerName = projectMaster.OwnerName,
                BuildCorporationCode = projectMaster.BuildCorporationCode,
                BuilderLicenceNum = projectMaster.BuilderLicenceNum,
                AreaCode = projectMaster.AreaCode,
                TotalContractAmt = projectMaster.TotalContractAmt,
                BuildingArea = projectMaster.BuildingArea,
                StartDate = projectMaster.StartDate,
                CompleteDate = projectMaster.CompleteDate,
                ProjectSource = projectMaster.ProjectSource,
                ProjectStatus = projectMaster.ProjectStatus
            };
            var result = _projectMaster.InsertProjectMaster(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_projectMaster")]
        public HttpResponseMessage UpdatePayRollDetai(ProjectMaster projectMaster)
        {
            if (projectMaster.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var obj = _projectMaster.GetProjectMasterById(projectMaster.Id);

            if (projectMaster.ProjectSource == null)
            {
                projectMaster.ProjectSource = obj.ProjectSource;
            }
            if (projectMaster.BuildProjectCode == null)
            {
                projectMaster.BuildProjectCode = obj.BuildProjectCode;
            }
            if (projectMaster.StartDate == null)
            {
                projectMaster.StartDate = obj.StartDate;
            }
            if (projectMaster.CompleteDate == null)
            {
                projectMaster.CompleteDate = obj.CompleteDate;
            }
            if (projectMaster.ProjectCode == null)
            {
                projectMaster.ProjectCode = obj.ProjectCode;
            }
            if (projectMaster.ContractorOrgCode == null)
            {
                projectMaster.ContractorOrgCode = obj.ContractorOrgCode;
            }
            if (projectMaster.ProjectName == null)
            {
                projectMaster.ProjectName = obj.ProjectName;
            }
            if (projectMaster.ProjectActivityType == null)
            {
                projectMaster.ProjectActivityType = obj.ProjectActivityType;
            }
            if (projectMaster.ProjectDescription == null)
            {
                projectMaster.ProjectDescription = obj.ProjectDescription;
            }
            var result = _projectMaster.UpdateProjectMaster(projectMaster);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}

