using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNKJ.Core.Data;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.ViewModel;

namespace JNKJ.Services.RealNameSystem.Realize
{
    public class WorkerAttendanceService : IWorkerAttendance
    {
        #region Fields

        private readonly IRepository<WorkerAttendance> _workerAttendance;
        private readonly IRepository<WorkerMaster> _workerMaster;
        #endregion

        #region Ctor

        public WorkerAttendanceService(IRepository<WorkerAttendance> workerAttendance,IRepository<WorkerMaster> workerMaster)
        {
            _workerAttendance = workerAttendance;
            _workerMaster = workerMaster;
        }
        #endregion

        /// <summary>
        /// Delete the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        public bool DeleteWorkerAttendance(WorkerAttendance workerAttendance)
        {
            if (workerAttendance == null) { throw new ArgumentException("workerAttendance is null"); }

            bool result = _workerAttendance.Delete(workerAttendance);

            return result;
        }

        /// <summary>
        ///  Get the WorkerAttendance by id
        /// </summary>
        /// <param name="workerAttendanceId"></param>
        /// <returns></returns>
        public WorkerAttendance GetWorkerAttendanceById(Guid workerAttendanceId)
        {
            if (Guid.Empty == workerAttendanceId) { return null; }

            var customer = _workerAttendance.GetById(workerAttendanceId);

            return customer;
        }

        public WorkerAttendance GetWorkerAttendanceByProjectCode(string ProjectCode)
        {
            var customer = _workerAttendance.Table.FirstOrDefault(s => s.ProjectCode == ProjectCode);

            return customer;
        }

        /// <summary>
        /// Get the WorkerAttendance paged list
        /// </summary>
        /// <param name="checkTime">打卡时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<WorkerAttendanceViewModel> GetWorkerAttendances(DateTime? checkTime, string projectCode = null, string iDCardNumber = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _workerAttendance.Table;

            if (checkTime.HasValue)
            {
                query = query.Where(c => checkTime.Value == c.CheckTime);
            }

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }

            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }

            var data = query.Select(t => new WorkerAttendanceViewModel
            {
                Id = t.Id,
                ProjectCode = t.ProjectCode,
                UserName = _workerMaster.Table.Where(p => p.IDCardNumber == t.IDCardNumber).Select(p => p.WorkerName).FirstOrDefault(),
                IDCardType = t.IDCardType,
                IDCardNumber = t.IDCardNumber,
                CheckTime = t.CheckTime,
                CheckType = t.CheckType,
                CheckChannel = t.CheckChannel,
                DataResource = t.DataResource
            }).ToList();

            var list = new PagedList<WorkerAttendanceViewModel>(data, pageIndex-1, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        public bool InsertWorkerAttendance(WorkerAttendance workerAttendance)
        {
            if (workerAttendance == null) { throw new ArgumentNullException("workerAttendance is null"); }

            bool result = _workerAttendance.Insert(workerAttendance);

            return result;
        }

        /// <summary>
        /// Updates the WorkerAttendance
        /// </summary>
        /// <param name="workerAttendance"></param>
        /// <returns></returns>
        public bool UpdateWorkerAttendance(WorkerAttendance workerAttendance)
        {
            if (workerAttendance == null) { throw new ArgumentNullException("workerAttendance is null"); }

            bool result = _workerAttendance.SingleUpdate(workerAttendance);

            return result;
        }
    }
}
