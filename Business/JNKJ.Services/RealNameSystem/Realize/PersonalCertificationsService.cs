using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class PersonalCertificationsService : IPersonalCertifications
    {
        #region Fields

        private readonly IRepository<PersonalCertifications> _personalCertificationsRepository;

        #endregion

        #region Ctor

        public PersonalCertificationsService(IRepository<PersonalCertifications> personalCertificationsRepository)
        {
            _personalCertificationsRepository = personalCertificationsRepository;
        }

        #endregion

        public bool DeletePersonalCertifications(PersonalCertifications personalCertifications)
        {
            if (personalCertifications == null) { throw new ArgumentNullException("personalCertifications is null"); }

            bool result = _personalCertificationsRepository.Delete(personalCertifications);

            return result;
        }

        public PersonalCertifications GetPersonalCertificationsById(Guid personalCertificationsId)
        {
            if (Guid.Empty == personalCertificationsId) { return null; }

            var customer = _personalCertificationsRepository.GetById(personalCertificationsId);

            return customer;
        }

        public IPagedList<PersonalCertifications> GetPersonalCertificationss(DateTime? issueDate, string iDCardNumber = null, int professionCode = -1, int jobType = -1, int status = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _personalCertificationsRepository.Table;

            if (issueDate.HasValue)
            {
                query = query.Where(c => c.IssueDate == issueDate);
            }
            if (!string.IsNullOrWhiteSpace(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (professionCode != -1)
            {
                query = query.Where(c => c.ProfessionCode == professionCode);
            }

            if (jobType != -1)
            {
                query = query.Where(c => c.JobType == jobType);
            }

            query = query.OrderByDescending(c => c.IssueDate);

            var list = new PagedList<PersonalCertifications>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertPersonalCertifications(PersonalCertifications personalCertifications)
        {
            if (personalCertifications == null) { throw new ArgumentNullException("personalCertifications is null"); }

            bool result = _personalCertificationsRepository.Insert(personalCertifications);

            return result;
        }

        public bool UpdatePersonalCertifications(PersonalCertifications personalCertifications)
        {
            if (personalCertifications == null) { throw new ArgumentNullException("personalCertifications is null"); }

            bool result = _personalCertificationsRepository.SingleUpdate(personalCertifications);

            return result;
        }
    }
}
