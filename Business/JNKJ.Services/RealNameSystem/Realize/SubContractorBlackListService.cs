using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    public class SubContractorBlackListService : ISubContractorBlackList
    {
        #region Fields

        private readonly IRepository<SubContractorBlackList> _subContractorBlackListRepository;

        #endregion

        #region Ctor

        public SubContractorBlackListService(IRepository<SubContractorBlackList> subContractorBlackListRepository)
        {
            _subContractorBlackListRepository = subContractorBlackListRepository;
        }

        #endregion
        public bool DeleteSubContractorBlackList(SubContractorBlackList subContractorBlackList)
        {
            if (subContractorBlackList == null) { throw new ArgumentNullException("company_employe is null"); }

            bool result = _subContractorBlackListRepository.Delete(subContractorBlackList);

            return result;
        }

        public SubContractorBlackList GetSubContractorByOrganizationCode(string organizationCode)
        {
            var customer = _subContractorBlackListRepository.Table.FirstOrDefault(s => s.OrganizationCode == organizationCode);

            return customer;
        }

        public IPagedList<SubContractorBlackList> GetSubContractorBlackLists(string organizationCode = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _subContractorBlackListRepository.Table;

            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }

            var list = new PagedList<SubContractorBlackList>(query, pageIndex, pageSize);
            return list;
        }

        public SubContractorBlackList GetSubContractorById(Guid subContractorBlackListId)
        {
            if (Guid.Empty == subContractorBlackListId) { return null; }

            var customer = _subContractorBlackListRepository.GetById(subContractorBlackListId);

            return customer;
        }

        public bool InsertSubContractorBlackList(SubContractorBlackList subContractorBlackList)
        {
            if (subContractorBlackList == null) { throw new ArgumentNullException("subContractorBlackList is null"); }

            bool result = _subContractorBlackListRepository.Insert(subContractorBlackList);

            return result;
        }

        public bool UpdateSubContractorBlackList(SubContractorBlackList subContractorBlackList)
        {
            if (subContractorBlackList == null) { throw new ArgumentNullException("subContractorBlackList is null"); }

            bool result = _subContractorBlackListRepository.SingleUpdate(subContractorBlackList);

            return result;
        }
    }
}
