using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class PayRollDetailService : IPayRollDetail
    {
        #region Fields

        private readonly IRepository<PayRollDetail> _payRollDetail;

        #endregion

        #region Ctor

        public PayRollDetailService(IRepository<PayRollDetail> payRollDetail)
        {
            _payRollDetail = payRollDetail;
        }
        #endregion

        /// <summary>
        /// Delete the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        public bool DeletePayRollDetail(PayRollDetail payRollDetail)
        {
            if (payRollDetail == null) { throw new ArgumentException("payRollDetail is null"); }

            bool result = _payRollDetail.Delete(payRollDetail);

            return result;
        }

        /// <summary>
        ///  Get the PayRollDetail by id
        /// </summary>
        /// <param name="payRollDetailId"></param>
        /// <returns></returns>
        public PayRollDetail GetPayRollDetailById(Guid payRollDetailId)
        {
            if (Guid.Empty == payRollDetailId) { return null; }

            var customer = _payRollDetail.GetById(payRollDetailId);

            return customer;
        }

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
        public IPagedList<PayRollDetail> GetPayRollDetails(DateTime? balanceDate, string payRollCode = null, string iDCardNumber = null, string payRollBankCardNumber = null, int payStatus = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _payRollDetail.Table;

            if (balanceDate.HasValue)
            {
                query = query.Where(c => balanceDate.Value == c.BalanceDate);
            }
            if (!string.IsNullOrEmpty(payRollCode))
            {
                query = query.Where(c => c.PayRollCode.Contains(payRollCode));
            }
            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (!string.IsNullOrEmpty(payRollBankCardNumber))
            {
                query = query.Where(c => c.PayRollBankCardNumber.Contains(payRollBankCardNumber));
            }
            if (payStatus == 0 || payStatus == 20 || payStatus==30 || payStatus==40)
            {
                query = query.Where(c => c.PayStatus == payStatus);
            }


            query = query.OrderByDescending(c => c.BalanceDate);


            var list = new PagedList<PayRollDetail>(query, pageIndex, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        public bool InsertPayRollDetail(PayRollDetail payRollDetail)
        {
            if (payRollDetail == null) { throw new ArgumentNullException("payRollDetail is null"); }

            bool result = _payRollDetail.Insert(payRollDetail);

            return result;
        }

        /// <summary>
        /// Updates the PayRollDetail
        /// </summary>
        /// <param name="payRollDetail"></param>
        /// <returns></returns>
        public bool UpdatePayRollDetail(PayRollDetail payRollDetail)
        {
            if (payRollDetail == null) { throw new ArgumentNullException("payRollDetail is null"); }

            bool result = _payRollDetail.SingleUpdate(payRollDetail);

            return result;
        }
    }
}
