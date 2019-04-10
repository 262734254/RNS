using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    public class SubContractorCertificationsService : ISubContractorCertifications
    {
        #region Fields

        private readonly IRepository<SubContractorCertifications> _subContractorCertificationsRepository;

        #endregion

        #region Ctor

        public SubContractorCertificationsService(IRepository<SubContractorCertifications> subContractorCertificationsRepository)
        {
            _subContractorCertificationsRepository = subContractorCertificationsRepository;
        }

        #endregion

        public bool DeleteSubContractorCertifications(SubContractorCertifications subContractorCertifications)
        {
            if (subContractorCertifications == null) { throw new ArgumentNullException("company_employe is null"); }

            bool result = _subContractorCertificationsRepository.Delete(subContractorCertifications);

            return result;
        }

        public SubContractorCertifications GetSubContractorCertificationsByOrganizationCode(string organizationCode)
        {
            var customer = _subContractorCertificationsRepository.Table.FirstOrDefault(s => s.OrganizationCode == organizationCode);

            return customer;
        }

        public SubContractorCertifications GetSubContractorCertificationsById(Guid subContractorCertificationsId)
        {
            if (Guid.Empty == subContractorCertificationsId) { return null; }

            var customer = _subContractorCertificationsRepository.GetById(subContractorCertificationsId);

            return customer;
        }

        public IPagedList<SubContractorCertifications> GetSubContractorCertificationss(string certificationName = null, string organizationCode = null, int qualificationStatus = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _subContractorCertificationsRepository.Table;

            if (!string.IsNullOrWhiteSpace(certificationName))
            {
                query = query.Where(c => c.CertificationName.Contains(certificationName));
            }

            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (qualificationStatus != -1)
            {
                query = query.Where(c => c.QualificationStatus == qualificationStatus);
            }

            query = query.OrderByDescending(c => c.RecentValidDate);

            var list = new PagedList<SubContractorCertifications>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertSubContractorCertifications(SubContractorCertifications subContractorCertifications)
        {
            if (subContractorCertifications == null) { throw new ArgumentNullException("subContractorCertifications is null"); }

            bool result = _subContractorCertificationsRepository.Insert(subContractorCertifications);

            return result;
        }

        public bool UpdateSubContractorCertifications(SubContractorCertifications subContractorCertifications)
        {
            if (subContractorCertifications == null) { throw new ArgumentNullException("subContractorCertifications is null"); }

            bool result = _subContractorCertificationsRepository.SingleUpdate(subContractorCertifications);

            return result;
        }
    }
}
