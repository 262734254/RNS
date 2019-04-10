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
    public class Company_EmployeController : BaseController
    {
        #region Fields

        private readonly ICompany_Employe _companyEmployeService;

        #endregion

        #region Ctor

        public Company_EmployeController(ICompany_Employe companyEmployeService)
        {
            _companyEmployeService = companyEmployeService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_companyemploye")]
        public HttpResponseMessage GetCompanyEmployes([FromUri]Company_EmployeRequest request)
        {
            var result = _companyEmployeService.GetCompanyEmployes(request.isAdmin, request.subContractorId, request.hireDate, request.terminationDate, request.organizationCode, request.jobStatus, request.workerRole, request.pageIndex, request.pageSize);

            var list = new PageList<Company_Employe>()
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
        [ActionName("get_companyemploye_by_id")]
        public HttpResponseMessage GetCompanyEmployeById([FromUri]Guid companyemployeId)
        {
            var result = _companyEmployeService.GetCompanyEmployeById(companyemployeId);

            return toJson(result, OperatingState.Success, "获取成功");
        }



        [HttpPost]
        [ActionName("delete_companyemploye")]
        public HttpResponseMessage DeleteCompanyEmploye([FromBody]Guid companyemployeId)
        {
            var obj = _companyEmployeService.GetCompanyEmployeById(companyemployeId);

            var result = _companyEmployeService.DeleteCompanyEmploye(obj);

            return result ? toJson(null, OperatingState.Success, "删除成功") : toJson(null, OperatingState.Failure, "删除失败");
        }


        [HttpPost]
        [ActionName("insert_companyemploye")]
        public HttpResponseMessage InsertCompanyEmploye(Company_Employe companyemploye)
        {
            companyemploye.Id = Guid.NewGuid();

            var result = _companyEmployeService.InsertCompanyEmploye(companyemploye);

            return result ? toJson(null, OperatingState.Success, "添加成功") : toJson(null, OperatingState.Failure, "添加失败");
        }



        [HttpPost]
        [ActionName("update_companyemploye")]
        public HttpResponseMessage UpdateCompanyEmploye(Company_Employe companyemploye)
        {
            var result = _companyEmployeService.UpdateCompanyEmploye(companyemploye);

            return result ? toJson(null, OperatingState.Success, "修改成功") : toJson(null, OperatingState.Failure, "修改失败");
        }
    }
}
