using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 项目信息--工资明细
    /// </summary>
    public interface IPayRollDetail
    {
        /// <summary>
        /// Get the PayRollDetail paged list
        /// </summary>
        /// <param name="balanceDate">银行发放日期 : 为空忽略</param>
        /// <param name="payRollCode">工资单编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件号码 : 为空忽略</param>
        /// <param name="payRollBankCardNumber">发放工资银行卡号 : 为空忽略</param>
        /// <param name="payStatus">状态 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<PayRollDetail> GetPayRollDetails(DateTime? balanceDate, string payRollCode = null,
            string iDCardNumber = null, string payRollBankCardNumber = null, int payStatus = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the PayRollDetail by id
        /// </summary>
        /// <param name="payRollDetailId"></param>
        /// <returns></returns>
        PayRollDetail GetPayRollDetailById(Guid payRollDetailId);


        /// <summary>
        /// Insert the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        bool InsertPayRollDetail(PayRollDetail payRollDetail);


        /// <summary>
        /// Updates the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        bool UpdatePayRollDetail(PayRollDetail payRollDetail);


        /// <summary>
        /// Delete the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        bool DeletePayRollDetail(PayRollDetail payRollDetail);
    }
}
