using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class WorkerBlackListService : IWorkerBlackList
    {
        #region Fields

        private readonly IRepository<WorkerBlackList> _workerBlackListRepository;

        #endregion

        #region Ctor

        public WorkerBlackListService(IRepository<WorkerBlackList> workerBlackListRepository)
        {
            _workerBlackListRepository = workerBlackListRepository;
        }

        #endregion

        public bool DeleteWorkerBlackList(WorkerBlackList workerBlackList)
        {
            if (workerBlackList == null) { throw new ArgumentNullException("workerBlackList is null"); }

            bool result = _workerBlackListRepository.Delete(workerBlackList);

            return result;
        }

        public WorkerBlackList GetWorkerBlackListById(Guid workerBlackListId)
        {
            if (Guid.Empty == workerBlackListId) { return null; }

            var customer = _workerBlackListRepository.GetById(workerBlackListId);

            return customer;
        }

        public IPagedList<WorkerBlackList> GetWorkerBlackLists(string projectCode = null, string organizationCode = null, string iDCardNumber = null, int teamSysNo = -1, string teamName = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _workerBlackListRepository.Table;

            if (!string.IsNullOrWhiteSpace(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (!string.IsNullOrWhiteSpace(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (teamSysNo != -1)
            {
                query = query.Where(c => c.TeamSysNo == teamSysNo);
            }
            if (!string.IsNullOrWhiteSpace(teamName))
            {
                query = query.Where(c => c.TeamName.Contains(teamName));
            }

            query = query.OrderByDescending(c => c.TeamSysNo);

            var list = new PagedList<WorkerBlackList>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertWorkerBlackList(WorkerBlackList workerBlackList)
        {
            if (workerBlackList == null|| workerBlackList.BlackReason==null|| workerBlackList.IDCardType==null|| workerBlackList.IDCardNumber==null|| workerBlackList.ProjectCode==null|| workerBlackList.ContractorOrgCode==null|| workerBlackList.OrganizationCode==null)
            { throw new ArgumentNullException("BlackReason/IDCardType/ProjectCode/ContractorOrgCode/OrganizationCode is null"); }

            bool result = _workerBlackListRepository.Insert(workerBlackList);

            return result;
        }

        public bool UpdateWorkerBlackList(WorkerBlackList workerBlackList)
        {
            if (workerBlackList == null) { throw new ArgumentNullException("workerBlackList is null"); }

            bool result = _workerBlackListRepository.SingleUpdate(workerBlackList);

            return result;
        }
    }
}
