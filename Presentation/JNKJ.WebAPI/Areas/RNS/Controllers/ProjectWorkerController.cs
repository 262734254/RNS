using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.Enums;
using JNKJ.Dto.RealNameSystem;
using JNKJ.Dto.Results;
using JNKJ.Dto.ViewModel;
using JNKJ.Services.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static JNKJ.Services.RealNameSystem.Realize.ProjectWorkerService;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class ProjectWorkerController : BaseController
    {
        #region Fields

        private readonly IProjectWorker _projectWorker;

        #endregion

        #region Ctor

        public ProjectWorkerController(IProjectWorker projectWorker)
        {
            _projectWorker = projectWorker;
        }

        #endregion

        [HttpGet]
        [ActionName("get_projectWorkers")]
        public HttpResponseMessage GetProjectWorkers([FromUri]ProjectWorkerRequest request)
        {
            var result = _projectWorker.GetProjectWorkers(request.IssueCardTime, request.projectCode, request.organizationCode,request.teamSysNo,request.iDCardNumber,request.cellPhone
                , request.pageIndex,request.pageSize);

            var list = new PageList<ProjectWorkerViewModel>()
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
        [ActionName("get_projectWorker_by_id")]
        public HttpResponseMessage GetProjectWorkerById([FromUri]Guid projectWorkerId)
        {
            var result = _projectWorker.GetProjectWorkerById(projectWorkerId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_projectWorker_by_projectCode")]
        public HttpResponseMessage GetProjectWorkerByProjectCode([FromUri]string projectCode)
        {
            var result = _projectWorker.GetProjectWorkerByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }


        [HttpPost]
        [ActionName("delete_projectWorker")]
        public HttpResponseMessage DeleteProjectWorkerId([FromBody]Guid projectWorkerId)
        {
            var obj = _projectWorker.GetProjectWorkerById(projectWorkerId);

            var result = _projectWorker.DeleteProjectWorker(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_projectWorker")]
        public HttpResponseMessage InsertProjectWorker( ProjectWorker projectWorker)
        {
            var newObj = new ProjectWorker()
            {
                Id = Guid.NewGuid(),
                ProjectCode = projectWorker.ProjectCode,
                OrganizationCode = projectWorker.OrganizationCode,
                TeamSysNo = projectWorker.TeamSysNo,
                IDCardType = projectWorker.IDCardType,
                IDCardNumber = projectWorker.IDCardNumber,
                WorkTypeCode = projectWorker.WorkTypeCode,
                CellPhone = projectWorker.CellPhone,
                IssueCardTime = projectWorker.IssueCardTime,
                EntryTime = projectWorker.EntryTime,
                ExitTime = projectWorker.ExitTime,
                CompleteCardTime = projectWorker.CompleteCardTime,
                CardNumber = projectWorker.CardNumber,
                CardType = projectWorker.CardType,
                HasContract = projectWorker.HasContract,
                ContractCode = projectWorker.ContractCode,
                WorkerAccommodationType = projectWorker.WorkerAccommodationType,
                WorkerRole = projectWorker.WorkerRole,
                PayRollBankCardNumber = projectWorker.PayRollBankCardNumber,
                PayRollBankName = projectWorker.PayRollBankName,
                HasBuyInsurance = projectWorker.HasBuyInsurance
            };  
            var result = _projectWorker.InsertProjectWorker(newObj);    

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_projectWorker")]
        public HttpResponseMessage UpdateProjectTraining(ProjectWorker projectWorker)
        {
            if (projectWorker.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var obj = _projectWorker.GetProjectWorkerById(projectWorker.Id);

            if (projectWorker.ProjectCode == null)
            {
                projectWorker.ProjectCode = obj.ProjectCode;
            }
            if (projectWorker.OrganizationCode == null)
            {
                projectWorker.OrganizationCode = obj.OrganizationCode;
            }
            if (projectWorker.TeamSysNo == null)
            {
                projectWorker.TeamSysNo = obj.TeamSysNo;
            }
            if (projectWorker.IDCardType == null)
            {
                projectWorker.IDCardType = obj.IDCardType;
            }
            if (projectWorker.IDCardNumber == null)
            {
                projectWorker.IDCardNumber = obj.IDCardNumber;
            }
            if (projectWorker.WorkTypeCode == null)
            {
                projectWorker.WorkTypeCode = obj.WorkTypeCode   ;
            }
            if (projectWorker.ProjectCode == null)
            {
                projectWorker.ProjectCode = obj.ProjectCode;
            }
            if (projectWorker.WorkerRole == null)
            {
                projectWorker.WorkerRole = obj.WorkerRole;
            }


            var result = _projectWorker.UpdateProjectWorker(projectWorker);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}

