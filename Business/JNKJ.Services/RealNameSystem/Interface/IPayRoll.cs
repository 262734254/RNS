using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--工资单
    /// </summary>
    public interface IPayRoll
    {
        /// <summary>
        /// Get the PayRoll paged list
        /// </summary>
        /// <param name="payMonth">发放工资的年月 : 为空忽略</param>
        /// <param name="payRollCode">工资单编号 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">企业组织机构代码 : 为空忽略</param>
        /// <param name="teamSysNo">班组编号 : 为空忽略</param>
        /// <param name="status">状态 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<PayRoll> GetPayRolls(DateTime? payMonth, string payRollCode = null, string projectCode = null, int? organizationCode = null,
            int? teamSysNo = null, int? status = -1, int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the PayRoll by id
        /// </summary>
        /// <param name="payRollId"></param>
        /// <returns></returns>
        PayRoll GetPayRollById(Guid payRollId);


        /// <summary>
        /// Insert the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        bool InsertPayRoll(PayRoll payRoll);


        /// <summary>
        /// Updates the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        bool UpdatePayRoll(PayRoll payRoll);


        /// <summary>
        /// Delete the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        bool DeletePayRoll(PayRoll payRoll);
    }
}
