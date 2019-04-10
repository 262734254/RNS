using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class WorkerGoodRecordsService : IWorkerGoodRecords
    {
        #region Fields

        private readonly IRepository<WorkerGoodRecords> _workerGoodRecordsRepository;

        #endregion

        #region Ctor

        public WorkerGoodRecordsService(IRepository<WorkerGoodRecords> workerGoodRecordsRepository)
        {
            _workerGoodRecordsRepository = workerGoodRecordsRepository;
        }

        #endregion

        public bool DeleteWorkerGoodRecords(WorkerGoodRecords workerGoodRecords)
        {
            if (workerGoodRecords == null) { throw new ArgumentNullException("workerGoodRecords is null"); }

            bool result = _workerGoodRecordsRepository.Delete(workerGoodRecords);

            return result;
        }

        public WorkerGoodRecords GetWorkerGoodRecordsById(Guid workerGoodRecordsId)
        {
            if (Guid.Empty == workerGoodRecordsId) { return null; }

            var customer = _workerGoodRecordsRepository.GetById(workerGoodRecordsId);

            return customer;
        }

        public IPagedList<WorkerGoodRecords> GetWorkerGoodRecordss(DateTime? occurrenceDate, string projectCode = null, string organizationCode = null, string iDCardNumber = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _workerGoodRecordsRepository.Table;

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

            var list = new PagedList<WorkerGoodRecords>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertWorkerGoodRecords(WorkerGoodRecords workerGoodRecords)
        {
            if (workerGoodRecords == null) { throw new ArgumentNullException("workerGoodRecords is null"); }

            bool result = _workerGoodRecordsRepository.Insert(workerGoodRecords);

            return result;
        }

        public bool UpdateWorkerGoodRecords(WorkerGoodRecords workerGoodRecords)
        {
            if (workerGoodRecords == null) { throw new ArgumentNullException("workerGoodRecords is null"); }

            bool result = _workerGoodRecordsRepository.SingleUpdate(workerGoodRecords);

            return result;
        }
    }
}
