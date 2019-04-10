using JNKJ.Core.Data;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.Enums;
using JNKJ.Dto.Results;
using JNKJ.Services.RealNameSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class PushManageService:IPushManage
    {
        #region Fields

        private readonly IRepository<ProjectMaster> _projectMaster;

        #endregion

        #region Ctor

        public PushManageService(IRepository<ProjectMaster> projectMaster)
        {
            _projectMaster = projectMaster;
        }

        #endregion

        public JsonResponse PushSubContractiorProjectInfo(string OrganizationCode)
        {
            try
            {
                var model = _projectMaster.Table.Where(t => t.ContractorOrgCode == OrganizationCode).FirstOrDefault();

                return new JsonResponse(OperatingState.Success, "推送数据成功");

            }
            catch (Exception ex)
            {
                return new JsonResponse(OperatingState.Success, "推送数据失败"+ ex.Message.ToString());

            }
        }
    }
}
