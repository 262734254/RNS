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
    public class Employee_MasterController : BaseController
    {
        #region Fields

        private readonly IEmployee_Master _employeeMasterService;

        #endregion

        #region Ctor

        public Employee_MasterController(IEmployee_Master employeeMasterService)
        {
            _employeeMasterService = employeeMasterService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_employeemasters")]
        public HttpResponseMessage GetEmployeeMasters([FromUri]Employee_MasterRequest request)
        {
            var result = _employeeMasterService.GetEmployeeMasters(request.birthday, request.employeeName, request.cellPhone, request.professionalType, request.pageIndex, request.pageSize);

            var list = new PageList<Employee_Master>()
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
        [ActionName("get_employeemaster_by_id")]
        public HttpResponseMessage GetEmployeeMasterById([FromUri]Guid employeemasterId)
        {
            var result = _employeeMasterService.GetEmployeeMasterById(employeemasterId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_employeemaster")]
        public HttpResponseMessage DeleteEmployeeMaster([FromBody]Guid employeemasterId)
        {
            var obj = _employeeMasterService.GetEmployeeMasterById(employeemasterId);

            var result = _employeeMasterService.DeleteEmployee_Master(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_employeemaster")]
        public HttpResponseMessage InsertEmployeeMaster(Employee_Master employeemaster)
        {
            employeemaster.Id = Guid.NewGuid();

            var result = _employeeMasterService.InsertEmployee_Master(employeemaster);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_employeemaster")]
        public HttpResponseMessage UpdateEmployeeMaster(Employee_Master employeemaster)
        {
            var result = _employeeMasterService.UpdateEmployee_Master(employeemaster);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
