using JNKJ.Dto.Enums;
using JNKJ.Services.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class PushManageController : ApiController
    {
        #region Fields

        private readonly IProjectMaster _projectMaster;

        #endregion

        #region Ctor

        public PushManageController(IProjectMaster projectMaster)
        {
            _projectMaster = projectMaster;
        }
        #endregion

        [HttpGet]
        [ActionName("push_SubContractiorProjectInfo")]
        public HttpResponseMessage PushSubContractiorProjectInfo(string OrganizationCode)
        {
            //var result = 
            //var list = new PageList<ProjectMaster>()
            //{
            //    PageIndex = result.PageIndex,
            //    PageSize = result.PageSize,
            //    TotalCount = result.TotalCount,
            //    TotalPages = result.TotalPages,
            //    Data = result.ToList()
            //};
            //return toListJson(list, OperatingState.Success, "获取成功");
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent("1", Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
    }

}

