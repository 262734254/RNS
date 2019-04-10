using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class ContractFileService : IContractFile
    {
        #region Fields

        private readonly IRepository<ContractFile> __contractFileRepository;

        #endregion

        #region Ctor

        public ContractFileService(IRepository<ContractFile> contractFileRepository)
        {
            __contractFileRepository = contractFileRepository;
        }
        #endregion

        /// <summary>
        /// Delete the SubContractor
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        public bool DeleteContractFile(ContractFile contractFile)
        {
            if (contractFile == null) { throw new ArgumentException("contractFile is null"); }

            bool result = __contractFileRepository.Delete(contractFile);

            return result;
        }

        /// <summary>
        /// Get the SubContractor by id
        /// </summary>
        /// <param name="contractFileId"></param>
        /// <returns></returns>
        public ContractFile GetContractFileById(Guid contractFileId)
        {
            if (Guid.Empty == contractFileId){ return null; }

            var customer = __contractFileRepository.GetById(contractFileId);

            return customer;
        }

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
        public IPagedList<ContractFile> GetContractFiles(string projectCode = null, 
            string organizationCode = null, string contractCode = null, string iDCardNumber = null, string fileName = null,
            int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = __contractFileRepository.Table;

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (!string.IsNullOrEmpty(contractCode))
            {
                query = query.Where(c => c.ContractCode.Contains(organizationCode));
            }
            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (!string.IsNullOrEmpty(fileName))
            {
                query = query.Where(c => c.FileName.Contains(fileName));
            }

            var list = new PagedList<ContractFile>(query.ToList(), pageIndex-1, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the ContractFile
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        public bool InsertContractFile(ContractFile contractFile)
        {
            if (contractFile == null) {throw new ArgumentNullException("contractFile is null"); }

            bool result = __contractFileRepository.Insert(contractFile);

            return result;
        }

        /// <summary>
        /// Updates the ContractFile
        /// </summary>
        /// <param name="contractFile"></param>
        /// <returns></returns>
        public bool UpdateContractFile(ContractFile contractFile)
        {
            if (contractFile == null) { throw new ArgumentNullException("contractFile is null"); }

            bool result = __contractFileRepository.SingleUpdate(contractFile);

            return result;
        }
    }
}
