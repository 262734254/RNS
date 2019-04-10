using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class WorkerBadRecordsService : IWorkerBadRecords
    {
        #region Fields

        private readonly IRepository<WorkerBadRecords> _workerBadRecordsRepository;

        #endregion

        #region Ctor

        public WorkerBadRecordsService(IRepository<WorkerBadRecords> workerBadRecordsRepository)
        {
            _workerBadRecordsRepository = workerBadRecordsRepository;
        }

        #endregion

        public bool DeleteWorkerBadRecords(WorkerBadRecords workerBadRecords)
        {
            if (workerBadRecords == null) { throw new ArgumentNullException("workerBadRecords is null"); }

            bool result = _workerBadRecordsRepository.Delete(workerBadRecords);

            return result;
        }

        public WorkerBadRecords GetWorkerBadRecordsById(Guid workerBadRecordsId)
        {
            if (Guid.Empty == workerBadRecordsId) { return null; }

            var customer = _workerBadRecordsRepository.GetById(workerBadRecordsId);

            return customer;
        }

        public IPagedList<WorkerBadRecords> GetWorkerBadRecordss(DateTime? occurrenceDate, string projectCode = null, string organizationCode = null, string iDCardNumber = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _workerBadRecordsRepository.Table;

            if (occurrenceDate.HasValue)
            {
                query = query.Where(c => c.OccurrenceDate == occurrenceDate);
            }
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

            query = query.OrderByDescending(c => c.OccurrenceDate);

            var list = new PagedList<WorkerBadRecords>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertWorkerBadRecords(WorkerBadRecords workerBadRecords)
        {
            if (workerBadRecords == null) { throw new ArgumentNullException("workerBadRecords is null"); }

            bool result = _workerBadRecordsRepository.Insert(workerBadRecords);

            return result;
        }

        public bool UpdateWorkerBadRecords(WorkerBadRecords workerBadRecords)
        {
            if (workerBadRecords == null) { throw new ArgumentNullException("workerBadRecords is null"); }

            bool result = _workerBadRecordsRepository.SingleUpdate(workerBadRecords);

            return result;
        }
    }
}
