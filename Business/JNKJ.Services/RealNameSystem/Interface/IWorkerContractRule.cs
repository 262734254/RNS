using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--项目中工人劳动合同信息
    /// </summary>
    public interface IWorkerContractRule
    {
        /// <summary>
        /// Get the WorkerContractRule paged list
        /// </summary>
        /// <param name="startDate">开始日期 : 为空忽略</param>
        /// <param name="endDate">结束时期 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="contractCode">合同编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<WorkerContractRule> GetWorkerContractRules(DateTime? startDate, DateTime? endDate, string projectCode = null,
            string organizationCode = null, string iDCardNumber = null, string contractCode = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the WorkerContractRule by id
        /// </summary>
        /// <param name="workerContractRuleId"></param>
        /// <returns></returns>
        WorkerContractRule GetWorkerContractRuleById(Guid workerContractRuleId);

        /// <summary>
        ///  Get the WorkerContractRule by ProjectCode
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        WorkerContractRule GetWorkerContractRuleByProjectCode(string ProjectCode);

        /// <summary>
        /// Insert the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        bool InsertWorkerContractRule(WorkerContractRule workerContractRule);


        /// <summary>
        /// Updates the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        bool UpdateWorkerContractRule(WorkerContractRule workerContractRule);


        /// <summary>
        /// Delete the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        bool DeleteWorkerContractRule(WorkerContractRule workerContractRule);
    }
}
