using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 企业信息--企业从业人员聘用关系
    /// </summary>
    public interface ICompany_Employe
    {
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
        IPagedList<Company_Employe> GetCompanyEmployes(bool isAdmin, Guid subContractorId, DateTime? hireDate, DateTime? terminationDate,
            string organizationCode = null, int jobStatus = -1, int workerRole = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the company_employe by id
        /// </summary>
        /// <param name="companyEmployeId"></param>
        /// <returns></returns>
        Company_Employe GetCompanyEmployeById(Guid companyEmployeId);


        /// <summary>
        /// Insert the company_employe
        /// </summary>
        /// <param name="company_employe"></param>
        /// <returns></returns>
        bool InsertCompanyEmploye(Company_Employe company_employe);


        /// <summary>
        /// Updates the company_employe
        /// </summary>
        /// <param name="company_employe"></param>
        /// <returns></returns>
        bool UpdateCompanyEmploye(Company_Employe company_employe);


        /// <summary>
        /// Delete the company_employe
        /// </summary>
        /// <param name="company_employe"></param>
        /// <returns></returns>
        bool DeleteCompanyEmploye(Company_Employe company_employe);

    }
}
