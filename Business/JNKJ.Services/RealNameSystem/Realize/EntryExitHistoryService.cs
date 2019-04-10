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
    public class EntryExitHistoryService : IEntryExitHistory
    {
        #region Fields

        private readonly IRepository<EntryExitHistory> __entryExitHistoryRepository;

        #endregion

        #region Ctor

        public EntryExitHistoryService(IRepository<EntryExitHistory> entryExitHistoryRepository)
        {
            __entryExitHistoryRepository = entryExitHistoryRepository;
        }
        #endregion

        /// <summary>
        /// Delete the SubContractor
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        public bool DeleteEntryExitHistory(EntryExitHistory entryExitHistory)
        {
            if (entryExitHistory == null) { throw new ArgumentException("entryExitHistory is null"); }

            bool result = __entryExitHistoryRepository.Delete(entryExitHistory);

            return result;
        }

        /// <summary>
        /// Get the SubContractor by id
        /// </summary>
        /// <param name="entryExitHistoryId"></param>
        /// <returns></returns>
        public EntryExitHistory GetEntryExitHistoryById(Guid entryExitHistoryId)
        {
            if (Guid.Empty == entryExitHistoryId) { return null; }

            var customer = __entryExitHistoryRepository.GetById(entryExitHistoryId);

            return customer;
        }

        public EntryExitHistory GetEntryExitHistorysByProjectCode(string ProjectCode)
        {
            var customer = __entryExitHistoryRepository.Table.FirstOrDefault(s => s.ProjectCode == ProjectCode);

            return customer;
        }

        /// <summary>
        /// Get the EntryExitHistory paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="type">类型 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<EntryExitHistory> GetEntryExitHistorys(string projectCode = null, string organizationCode = null, string iDCardNumber = null, int type = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = __entryExitHistoryRepository.Table;

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (type ==0 || type == 1)
            {
                query = query.Where(c => c.Type == type);
            }
            

            query = query.OrderByDescending(c => c.Date);


            var list = new PagedList<EntryExitHistory>(query, pageIndex, pageSize);
            return list;
        }


        /// <summary>
        /// Insert the EntryExitHistory
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        public bool InsertEntryExitHistory(EntryExitHistory entryExitHistory)
        {
            if (entryExitHistory == null) { throw new ArgumentNullException("entryExitHistory is null"); }

            bool result = __entryExitHistoryRepository.Insert(entryExitHistory);

            return result;
        }

        /// <summary>
        /// Updates the ContractFile
        /// </summary>
        /// <param name="entryExitHistory"></param>
        /// <returns></returns>
        public bool UpdateEntryExitHistory(EntryExitHistory entryExitHistory)
        {
            if (entryExitHistory == null) { throw new ArgumentNullException("entryExitHistory is null"); }

            bool result = __entryExitHistoryRepository.SingleUpdate(entryExitHistory);

            return result;
        }
    }
}
