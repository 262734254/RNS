using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 企业信息--企业资质
    /// </summary>
    public interface ISubContractorCertifications
    {

        /// <summary>
        /// Get the SubContractorCertifications paged list
        /// </summary>
        /// <param name="certificationName">证书名称 : 为空忽略</param>
        /// <param name="organizationCode">组织机构编号 : 为空忽略</param>
        /// <param name="qualificationStatus">资质状态 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<SubContractorCertifications> GetSubContractorCertificationss(string certificationName = null, string organizationCode = null, int qualificationStatus = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the SubContractorCertifications by id
        /// </summary>
        /// <param name="subContractorCertificationsId"></param>
        /// <returns></returns>
        SubContractorCertifications GetSubContractorCertificationsById(Guid subContractorCertificationsId);


        /// <summary>
        /// Insert the SubContractorCertifications
        /// </summary>
        /// <param name="subContractorCertifications"></param>
        /// <returns></returns>
        bool InsertSubContractorCertifications(SubContractorCertifications subContractorCertifications);


        /// <summary>
        /// Updates the SubContractorCertifications
        /// </summary>
        /// <param name="subContractorCertifications"></param>
        /// <returns></returns>
        bool UpdateSubContractorCertifications(SubContractorCertifications subContractorCertifications);


        /// <summary>
        /// Delete the SubContractorCertifications
        /// </summary>
        /// <param name="subContractorCertifications"></param>
        /// <returns></returns>
        bool DeleteSubContractorCertifications(SubContractorCertifications subContractorCertifications);


        /// <summary>
        ///  Get the SubContractorCertifications by id
        /// </summary>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        SubContractorCertifications GetSubContractorCertificationsByOrganizationCode(string organizationCode);

    }
}
