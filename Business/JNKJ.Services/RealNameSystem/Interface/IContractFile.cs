using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--合同附件表
    /// </summary>
    public interface IContractFile
    {

        /// <summary>
        /// Get the ContractFile paged list
        /// </summary>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="contractCode">合同编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="fileName">附件名称 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<ContractFile> GetContractFiles(string projectCode = null, string organizationCode = null,
            string contractCode = null, string iDCardNumber = null, string fileName = null,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the ContractFile by id
        /// </summary>
        /// <param name="contractFileId"></param>
        /// <returns></returns>
        ContractFile GetContractFileById(Guid contractFileId);


        /// <summary>
        /// Insert the ContractFile
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        bool InsertContractFile(ContractFile contractFile);


        /// <summary>
        /// Updates the ContractFile
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        bool UpdateContractFile(ContractFile contractFile);


        /// <summary>
        /// Delete the ContractFile
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        bool DeleteContractFile(ContractFile contractFile);
    }
}
