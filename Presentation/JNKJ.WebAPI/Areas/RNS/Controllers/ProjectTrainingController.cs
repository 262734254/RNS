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
    public class ProjectTrainingController : BaseController
    {
        #region Fields

        private readonly IProjectTraining _projectTraining;

        #endregion

        #region Ctor

        public ProjectTrainingController(IProjectTraining projectTraining)
        {
            _projectTraining = projectTraining;
        }

        #endregion

        [HttpGet]
        [ActionName("get_projectTrainings")]
        public HttpResponseMessage GetProjectTrainings([FromUri]ProjectTrainingRequest request)
        {
            var result = _projectTraining.GetProjectTrainings(request.trainingTime, request.projectCode, request.trainingName, request.pageIndex,
                request.pageSize);

            var list = new PageList<ProjectTraining>()
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
        [ActionName("get_projectTraining_by_id")]
        public HttpResponseMessage GetProjectTrainingById([FromUri]Guid projectTrainingId)
        {
            var result = _projectTraining.GetProjectTrainingById(projectTrainingId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpGet]
        [ActionName("get_projectTraining_by_projectCode")]
        public HttpResponseMessage GetProjectTrainingByProjectCode([FromUri]string projectCode)
        {
            var result = _projectTraining.GetProjectTrainingByProjectCode(projectCode);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpPost]
        [ActionName("delete_projectTraining")]
        public HttpResponseMessage DeleteProjectTrainingId([FromBody]Guid projectTrainingId)
        {
            var obj = _projectTraining.GetProjectTrainingById(projectTrainingId);

            var result = _projectTraining.DeleteProjectTraining(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_projectTraining")]
        public HttpResponseMessage InsertProjectTraining(ProjectTraining projectTraining)
        {
            var newObj = new ProjectTraining()
            {
                Id = Guid.NewGuid(),
                ProjectCode = projectTraining.ProjectCode,
                TrainingTime = projectTraining.TrainingTime,
                TrainingDuration = projectTraining.TrainingDuration,
                TrainingName = projectTraining.TrainingName,
                TrainingTypeCode = projectTraining.TrainingTypeCode,
                Trainer = projectTraining.Trainer,
                Description = projectTraining.Description,
                Workers = projectTraining.Workers
            };
            var result = _projectTraining.InsertProjectTraining(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_projectTraining")]
        public HttpResponseMessage UpdateProjectTraining(ProjectTraining projectTraining)
        {
            if (projectTraining.Id == Guid.Empty)
            {
                return toJson(null, OperatingState.Failure, "Id不能为空");
            }

            var obj = _projectTraining.GetProjectTrainingById(projectTraining.Id);

            if (projectTraining.TrainingTime == null)
            {
                projectTraining.TrainingTime = obj.TrainingTime;
            }


            var result = _projectTraining.UpdateProjectTraining(projectTraining);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
