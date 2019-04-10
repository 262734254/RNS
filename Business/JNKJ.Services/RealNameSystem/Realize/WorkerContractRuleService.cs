using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class WorkerContractRuleService : IWorkerContractRule
    {
        #region Fields

        private readonly IRepository<WorkerContractRule> _workerContractRule;

        #endregion

        #region Ctor

        public WorkerContractRuleService(IRepository<WorkerContractRule> workerContractRule)
        {
            _workerContractRule = workerContractRule;
        }
        #endregion

        /// <summary>
        /// Delete the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        public bool DeleteWorkerContractRule(WorkerContractRule workerContractRule)
        {
            if (workerContractRule == null) { throw new ArgumentException("workerContractRule is null"); }

            bool result = _workerContractRule.Delete(workerContractRule);

            return result;
        }

        /// <summary>
        ///  Get the WorkerContractRule by id
        /// </summary>
        /// <param name="workerContractRuleId"></param>
        /// <returns></returns>
        public WorkerContractRule GetWorkerContractRuleById(Guid workerContractRuleId)
        {
            if (Guid.Empty == workerContractRuleId) { return null; }

            var customer = _workerContractRule.GetById(workerContractRuleId);

            return customer;
        }

        public WorkerContractRule GetWorkerContractRuleByProjectCode(string ProjectCode)
        {
            var customer = _workerContractRule.Table.FirstOrDefault(s => s.ProjectCode == ProjectCode);

            return customer;
        }

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
        public IPagedList<WorkerContractRule> GetWorkerContractRules(DateTime? startDate, DateTime? endDate, string projectCode = null, string organizationCode = null, string iDCardNumber = null, string contractCode = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _workerContractRule.Table;

            if (startDate.HasValue)
            {
                query = query.Where(c => startDate.Value == c.StartDate);
            }

            if (endDate.HasValue)
            {
                query = query.Where(c => endDate.Value == c.EndDate);
            }

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }

            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }

            if (!string.IsNullOrEmpty(contractCode))
            {
                query = query.Where(c => c.ContractCode.Contains(contractCode));
            }

            var list = new PagedList<WorkerContractRule>(query.ToList(), pageIndex - 1, pageSize);
            return list;
        }


        /// <summary>
        /// Insert the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        public bool InsertWorkerContractRule(WorkerContractRule workerContractRule)
        {
            if (workerContractRule == null) { throw new ArgumentNullException("workerContractRule is null"); }

            bool result = _workerContractRule.Insert(workerContractRule);

            return result;
        }

        /// <summary>
        /// Updates the WorkerContractRule
        /// </summary>
        /// <param name="workerContractRule"></param>
        /// <returns></returns>
        public bool UpdateWorkerContractRule(WorkerContractRule workerContractRule)
        {
            if (workerContractRule == null) { throw new ArgumentNullException("workerContractRule is null"); }

            bool result = _workerContractRule.SingleUpdate(workerContractRule);

            return result;
        }
    }
}
