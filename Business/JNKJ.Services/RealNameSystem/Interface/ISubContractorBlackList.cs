using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 企业信息--企业黑名单信息
    /// </summary>
    public interface ISubContractorBlackList
    {
        /// <summary>
        /// Get the SubContractorBlackList paged list
        /// </summary>
        /// <param name="organizationCode">组织机构编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<SubContractorBlackList> GetSubContractorBlackLists(string organizationCode = null, int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the SubContractorBlackList by id
        /// </summary>
        /// <param name="subContractorBlackListId"></param>
        /// <returns></returns>
        SubContractorBlackList GetSubContractorById(Guid subContractorBlackListId);


        /// <summary>
        /// Insert the SubContractorBlackList
        /// </summary>
        /// <param name="subContractorBlackList"></param>
        /// <returns></returns>
        bool InsertSubContractorBlackList(SubContractorBlackList subContractorBlackList);


        /// <summary>
        /// Updates the SubContractorBlackList
        /// </summary>
        /// <param name="subContractorBlackList"></param>
        /// <returns></returns>
        bool UpdateSubContractorBlackList(SubContractorBlackList subContractorBlackList);


        /// <summary>
        /// Delete the SubContractorBlackList
        /// </summary>
        /// <param name="subContractorBlackList"></param>
        /// <returns></returns>
        bool DeleteSubContractorBlackList(SubContractorBlackList subContractorBlackList);


        /// <summary>
        ///  Get the SubContractorBlackList by OrganizationCode
        /// </summary>
        /// <param name="organizationCode"></param>
        /// <returns></returns>
        SubContractorBlackList GetSubContractorByOrganizationCode(string organizationCode);

    }
}
