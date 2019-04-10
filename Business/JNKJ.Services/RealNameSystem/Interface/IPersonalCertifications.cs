using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 工人信息--人员资格证书信息
    /// </summary>
    public interface IPersonalCertifications
    {
        /// <summary>
        /// Get the PersonalCertifications paged list
        /// </summary>
        /// <param name="issueDate">发证日期 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="professionCode">专业编码 : -1时忽略</param>
        /// <param name="jobType">类别/工种 : -1时忽略</param>
        /// <param name="status">资格状态 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<PersonalCertifications> GetPersonalCertificationss(DateTime? issueDate, string iDCardNumber = null,
            int professionCode = -1, int jobType = -1, int status = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the PersonalCertifications by id
        /// </summary>
        /// <param name="personalCertificationsId"></param>
        /// <returns></returns>
        PersonalCertifications GetPersonalCertificationsById(Guid personalCertificationsId);


        /// <summary>
        /// Insert the PersonalCertifications
        /// </summary>
        /// <param name="personalCertifications"></param>
        /// <returns></returns>
        bool InsertPersonalCertifications(PersonalCertifications personalCertifications);


        /// <summary>
        /// Updates the PersonalCertifications
        /// </summary>
        /// <param name="personalCertifications"></param>
        /// <returns></returns>
        bool UpdatePersonalCertifications(PersonalCertifications personalCertifications);


        /// <summary>
        /// Delete the PersonalCertifications
        /// </summary>
        /// <param name="personalCertifications"></param>
        /// <returns></returns>
        bool DeletePersonalCertifications(PersonalCertifications personalCertifications);
    }
}
