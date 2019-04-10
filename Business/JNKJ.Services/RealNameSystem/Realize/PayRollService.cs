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
    public class PayRollService : IPayRoll
    {
        #region Fields

        private readonly IRepository<PayRoll> _payRollServiceRepository;

        #endregion

        #region Ctor

        public PayRollService(IRepository<PayRoll> payRollServiceRepository)
        {
            _payRollServiceRepository = payRollServiceRepository;
        }
        #endregion

        /// <summary>
        /// Delete the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        public bool DeletePayRoll(PayRoll payRoll)
        {
            if (payRoll == null) { throw new ArgumentException("payRoll is null"); }

            bool result = _payRollServiceRepository.Delete(payRoll);

            return result;
        }

        /// <summary>
        ///  Get the PayRoll by id
        /// </summary>
        /// <param name="payRollId"></param>
        /// <returns></returns>
        public PayRoll GetPayRollById(Guid payRollId)
        {
            if (Guid.Empty == payRollId) { return null; }

            var customer = _payRollServiceRepository.GetById(payRollId);

            return customer;
        }

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
        public IPagedList<PayRoll> GetPayRolls(DateTime? payMonth, string payRollCode = null, string projectCode = null, int? organizationCode = null, int? teamSysNo = null, int? status = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _payRollServiceRepository.Table;


            if (payMonth.HasValue)
            {
                query = query.Where(c => payMonth.Value == c.PayMonth);
            }

            if (!string.IsNullOrEmpty(payRollCode))
            {
                query = query.Where(c => c.PayRollCode.Contains(payRollCode));
            }

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            //if (organizationCode != null)
            //{
            //    query = query.Where(c => c.OrganizationCode == organizationCode);
            //}
            //if (teamSysNo != null)
            //{
            //    query = query.Where(c => c.TeamSysNo == teamSysNo);
            //}
            if (status == 2 || status == 3 || status == 50)
            {
                query = query.Where(c => c.Status == status);
            }

            query = query.OrderByDescending(c => c.PayMonth);

            var list = new PagedList<PayRoll>(query, pageIndex, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        public bool InsertPayRoll(PayRoll payRoll)
        {
            if (payRoll == null) { throw new ArgumentNullException("payRoll is null"); }

            bool result = _payRollServiceRepository.Insert(payRoll);

            return result;
        }

        /// <summary>
        /// Updates the PayRoll
        /// </summary>
        /// <param name="payRoll"></param>
        /// <returns></returns>
        public bool UpdatePayRoll(PayRoll payRoll)
        {
            if (payRoll == null) { throw new ArgumentNullException("payRoll is null"); }
            
            bool result = _payRollServiceRepository.SingleUpdate(payRoll);

            return result;
        }
    }
}
