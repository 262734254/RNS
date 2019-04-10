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
    public class ProjectWorkerService : IProjectWorker
    {
        #region Fields

        private readonly IRepository<ProjectWorker> _projectWorker;
        private readonly IRepository<WorkerMaster> _workerMaster;
        
        #endregion

        #region Ctor

        public ProjectWorkerService(IRepository<ProjectWorker> projectWorker, IRepository<WorkerMaster> workerMaster)
        {
            _projectWorker = projectWorker;
            _workerMaster = workerMaster;
        }
        #endregion

        /// <summary>
        /// Delete the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        public bool DeleteProjectWorker(ProjectWorker projectWorker)
        {
            if (projectWorker == null) { throw new ArgumentException("projectWorker is null"); }

            bool result = _projectWorker.Delete(projectWorker);

            return result;
        }

        /// <summary>
        ///  Get the ProjectWorker by id
        /// </summary>
        /// <param name="projectWorkerId"></param>
        /// <returns></returns>
        public ProjectWorker GetProjectWorkerById(Guid projectWorkerId)
        {
            if (Guid.Empty == projectWorkerId) { return null; }

            var customer = _projectWorker.GetById(projectWorkerId);

            return customer;
        }

        public ProjectWorker GetProjectWorkerByProjectCode(string ProjectCode)
        {
            var customer = _projectWorker.Table.FirstOrDefault(s => s.ProjectCode == ProjectCode);

            return customer;
        }

        /// <summary>
        /// Get the ProjectWorker paged list
        /// </summary>
        /// <param name="IssueCardTime">发卡时间 : 为空忽略</param>
        /// <param name="projectCode">项目编号 : 为空忽略</param>
        /// <param name="organizationCode">所属企业组织机构代码 : 为空忽略</param>
        /// <param name="teamSysNo">班组编号 : 为空忽略</param>
        /// <param name="iDCardNumber">证件编号 : 为空忽略</param>
        /// <param name="cellPhone">手机号码 : 为空忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public IPagedList<ProjectWorkerViewModel> GetProjectWorkers(DateTime? IssueCardTime, string projectCode = null, string organizationCode = null, string teamSysNo = null,
                            string iDCardNumber = null, string cellPhone = null, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX)
            {
                pageIndex = ConstKeys.DEFAULT_PAGEINDEX;
            }

            if (pageSize <= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT)
            {
                pageSize = ConstKeys.DEFAULT_PAGESIZE;
            }

            var query = _projectWorker.Table;

            if (IssueCardTime.HasValue)
            {
                query = query.Where(c => IssueCardTime.Value == c.IssueCardTime);
            }

            if (!string.IsNullOrEmpty(projectCode))
            {
                query = query.Where(c => c.ProjectCode.Contains(projectCode));
            }
            if (!string.IsNullOrEmpty(organizationCode))
            {
                query = query.Where(c => c.OrganizationCode.Contains(organizationCode));
            }
            if (!string.IsNullOrEmpty(iDCardNumber))
            {
                query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
            }
            if (!string.IsNullOrEmpty(cellPhone))
            {
                query = query.Where(c => c.CellPhone.Contains(cellPhone));
            }

            var teamSysNo_Int = Convert.ToInt32(teamSysNo);
            if (teamSysNo_Int > 0)
            {
                query = query.Where(c => c.TeamSysNo == teamSysNo_Int);
            }
            
            var data = query.OrderBy(t=>t.TeamSysNo).Select(t => new ProjectWorkerViewModel
            {
                Id = t.Id,
                WorkTypeCode =t.WorkTypeCode,
                UserName = _workerMaster.Table.Where(p => p.IDCardNumber == t.IDCardNumber).Select(p => p.WorkerName).FirstOrDefault(),
                WorkerRole = t.WorkerRole,
                WorkerAccommodationType = t.WorkerAccommodationType,
                TeamSysNo = t.TeamSysNo,
                ProjectCode =t.ProjectCode,
                PayRollBankName =t.PayRollBankName,
                PayRollBankCardNumber=t.PayRollBankCardNumber,
                OrganizationCode=t.OrganizationCode,
                IssueCardTime=t.IssueCardTime,
                IDCardType=t.IDCardType,
                IDCardNumber =t.IDCardNumber,
                HasContract=t.HasContract,
                HasBuyInsurance=t.HasBuyInsurance,
                ExitTime=t.ExitTime,
                EntryTime=t.EntryTime,
                ContractCode=t.ContractCode,
                CompleteCardTime=t.CompleteCardTime,
                CellPhone=t.CellPhone,
                CardType=t.CardType,
                CardNumber=t.CardNumber
            }).ToList();
            
            var list = new PagedList<ProjectWorkerViewModel>(data, pageIndex-1, pageSize);
            return list;
        }

        /// <summary>
        /// Insert the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        public bool InsertProjectWorker(ProjectWorker projectWorker)
        {
            if (projectWorker == null) { throw new ArgumentNullException("projectWorker is null"); }

            bool result = _projectWorker.Insert(projectWorker);

            return result;
        }

        /// <summary>
        /// Updates the ProjectWorker
        /// </summary>
        /// <param name="projectWorker"></param>
        /// <returns></returns>
        public bool UpdateProjectWorker(ProjectWorker projectWorker)
        {
            if (projectWorker == null) { throw new ArgumentNullException("projectWorker is null"); }

            bool result = _projectWorker.SingleUpdate(projectWorker);

            return result;
        }
    }
}
