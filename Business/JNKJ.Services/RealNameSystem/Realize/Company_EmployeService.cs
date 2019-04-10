using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;

namespace JNKJ.Services.RealNameSystem
{
    public class Company_EmployeService : ICompany_Employe
    {
        #region Fields

        private readonly IRepository<Company_Employe> _companyEmployeRepository;
        private readonly IRepository<SubContractor> _subContractorRepository;

        #endregion

        #region Ctor

        public Company_EmployeService(IRepository<Company_Employe> companyEmployeRepository, IRepository<SubContractor> subContractorRepository)
        {
            _companyEmployeRepository = companyEmployeRepository;
            _subContractorRepository = subContractorRepository;
        }

        #endregion

        /// <summary>
        /// Get the company_employe paged list
        /// </summary>
        /// <param name="hireDate">入职日期 : 为空忽略</param>
        /// <param name="terminationDate">离职日期 : 为空忽略</param>
        /// <param name="organizationCode">组织机构编号 : 为空忽略</param>
        /// <param name="jobStatus">状态 : -1时忽略</param>
        /// <param name="workerRole">角色 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<Company_Employe> GetCompanyEmployes(bool isAdmin, Guid subContractorId, DateTime? hireDate, DateTime? terminationDate, string organizationCode = null, int jobStatus = -1, int workerRole = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _companyEmployeRepository.Table;

            if (!isAdmin)
            {
                var subContractor = _subContractorRepository.GetById(subContractorId);
                if (subContractor != null)
                {
                    query = query.Where(s => s.OrganizationCode == subContractor.OrganizationCode);
                }
                else
                {
                    return new PagedList<Company_Employe>(new List<Company_Employe>(), pageIndex, pageSize);
                }
            }

            if (hireDate.HasValue)
            {
                query = query.Where(c => hireDate.Value == c.HireDate);
            }
            if (terminationDate.HasValue)
            {
                query = query.Where(c => terminationDate.Value == c.TerminationDate);
            }
            if (!string.IsNullOrWhiteSpace(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (jobStatus != -1)
            {
                query = query.Where(c => c.JobStatus == jobStatus);
            }
            if (workerRole != -1)
            {
                query = query.Where(c => c.WorkerRole == workerRole);
            }

            query = query.OrderByDescending(c => c.HireDate);

            var list = new PagedList<Company_Employe>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertCompanyEmploye(Company_Employe company_employe)
        {
            if (company_employe == null) { throw new ArgumentNullException("company_employe is null"); }

            bool result = _companyEmployeRepository.Insert(company_employe);

            return result;
        }

        public bool UpdateCompanyEmploye(Company_Employe company_employe)
        {
            if (company_employe == null) { throw new ArgumentNullException("company_employe is null"); }

            bool result = _companyEmployeRepository.SingleUpdate(company_employe);

            return result;
        }


        public bool DeleteCompanyEmploye(Company_Employe company_employe)
        {
            if (company_employe == null) { throw new ArgumentNullException("company_employe is null"); }

            bool result = _companyEmployeRepository.Delete(company_employe);

            return result;
        }


        public Company_Employe GetCompanyEmployeById(Guid companyEmployeId)
        {
            if (Guid.Empty == companyEmployeId) { return null; }

            var customer = _companyEmployeRepository.GetById(companyEmployeId);

            return customer;
        }
    }
}
