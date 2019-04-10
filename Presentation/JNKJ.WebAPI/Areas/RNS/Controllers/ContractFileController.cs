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
    public class ContractFileController : BaseController
    {
        #region Fields

        private readonly IContractFile _contractFileService;

        #endregion

        #region Ctor

        public ContractFileController(IContractFile contractFileService)
        {
            _contractFileService = contractFileService;
        }

        #endregion



        [HttpGet]
        [ActionName("get_contractFile")]
        public HttpResponseMessage GetContractFiles([FromUri]ContractFilesRequest request)
        {
            var result = _contractFileService.GetContractFiles(request.contractCode, request.iDCardNumber, request.organizationCode, request.organizationCode, request.projectCode,
                request.pageSize);

            PageList<ContractFile> list = new PageList<ContractFile>()
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
        [ActionName("get_contractFile_by_id")]
        public HttpResponseMessage GetContractFileById([FromUri]Guid contractFileId)
        {
            var result = _contractFileService.GetContractFileById(contractFileId);

            return toJson(result, OperatingState.Success, "获取成功");
        }

        [HttpPost]
        [ActionName("insert_contractFile")]
        public HttpResponseMessage InsertContractFile(ContractFile contractFile)
        {
            var newObj = new ContractFile
            {
                Id = Guid.NewGuid(),
                ProjectCode = contractFile.ProjectCode,
                OrganizationCode = contractFile.OrganizationCode,
                ContractCode = contractFile.ContractCode,
                IDCardNumber = contractFile.IDCardNumber,
                IDCardType = contractFile.IDCardType,
                FileName = contractFile.FileName,
                FilePath = contractFile.FilePath
            };

            var result = _contractFileService.InsertContractFile(newObj);

            if (result) { return toJson(null, OperatingState.Success, "添加成功"); }
            return toJson(null, OperatingState.Failure, "添加失败");
        }

        [HttpPost]
        [ActionName("delete_contractFile")]
        public HttpResponseMessage DeleteContractFile([FromBody]Guid contractFileId)
        {
            var obj = _contractFileService.GetContractFileById(contractFileId);

            var result = _contractFileService.DeleteContractFile(obj);

            if (result) { return toJson(null, OperatingState.Success, "删除成功"); }

            return toJson(null, OperatingState.Failure, "删除失败");
        }

        [HttpPost]
        [ActionName("update_contractFile")]
        public HttpResponseMessage UpdateContractFile(ContractFile contractFile)
        {
            var result = _contractFileService.UpdateContractFile(contractFile);

            if (result) { return toJson(null, OperatingState.Success, "修改成功"); }
            return toJson(null, OperatingState.Failure, "修改失败");
        }

    }
}
