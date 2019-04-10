using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;
using System.Text;
using System.Collections.Generic;
using JNKJ.Core.Infrastructure;
using JNKJ.Services.Qiniu;

namespace JNKJ.Services.RealNameSystem
{
    public class WorkerMasterService : IWorkerMaster
    {
        #region Fields

        private readonly IRepository<WorkerMaster> _workerMasterRepository;

        #endregion

        #region Ctor

        public WorkerMasterService(IRepository<WorkerMaster> workerMasterRepository)
        {
            _workerMasterRepository = workerMasterRepository;
        }

        #endregion


        public bool DeleteWorkerMaster(WorkerMaster workerMaster)
        {
            if (workerMaster == null) { throw new ArgumentNullException("workerMaster is null"); }

            bool result = _workerMasterRepository.Delete(workerMaster);

            return result;
        }

        public WorkerMaster GetWorkerMasterById(Guid workerMasterId)
        {
            if (Guid.Empty == workerMasterId) { return null; }

            var customer = _workerMasterRepository.GetById(workerMasterId);

            return customer;
        }

        public IPagedList<WorkerMasterResponse> GetWorkerMasters(DateTime? joinedTime, string workerName = null, string iDCardNumber = null, string cellPhone = null, int pageIndex = 1, int pageSize = 100)
        {
            try
            {
                if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
                if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

                var query = _workerMasterRepository.Table;

                if (joinedTime.HasValue)
                {
                    query = query.Where(c => c.JoinedTime == joinedTime);
                }

                if (!string.IsNullOrWhiteSpace(workerName))
                {
                    query = query.Where(c => c.WorkerName.Contains(workerName));
                }
                if (!string.IsNullOrWhiteSpace(iDCardNumber))
                {
                    query = query.Where(c => c.IDCardNumber.Contains(iDCardNumber));
                }
                if (!string.IsNullOrWhiteSpace(cellPhone))
                {
                    query = query.Where(c => c.CellPhone.Contains(cellPhone));
                }
                var result = new List<WorkerMasterResponse>();
                var qiniu = EngineContext.Current.Resolve<IQiniuService>();
                foreach (var item in query)
                {
                    WorkerMasterResponse rep = new WorkerMasterResponse();
                    rep.Id = item.Id;
                    rep.Address = item.Address;
                    rep.WorkerName = item.WorkerName;
                    rep.IDCardType = item.IDCardType;
                    rep.IDCardNumber = item.IDCardNumber;
                    rep.Gender = item.Gender;
                    rep.Nation = item.Nation;
                    rep.Birthday = item.Birthday;
                    rep.BirthPlaceCode = item.BirthPlaceCode;
                    rep.HeadImage = item.HeadImage == null ? null : qiniu.DownLoadPrivateUrl(Encoding.UTF8.GetString(item.HeadImage));
                    rep.PoliticsType = item.PoliticsType;
                    rep.IsJoined = item.IsJoined;
                    rep.JoinedTime = item.JoinedTime;
                    rep.CellPhone = item.CellPhone;
                    rep.CultureLevelType = item.CultureLevelType;
                    rep.HasBadMedicalHistory = item.HasBadMedicalHistory;
                    rep.UrgentContractName = item.UrgentContractName;
                    rep.UrgentContractCellphone = item.UrgentContractCellphone;
                    rep.WorkTypeCode = item.WorkTypeCode;
                    rep.WorkDate = item.WorkDate;
                    result.Add(rep);
                }

                return new PagedList<WorkerMasterResponse>(result, pageIndex - 1, pageSize);
            }
            catch (Exception ex)
            {
                return new PagedList<WorkerMasterResponse>(new List<WorkerMasterResponse>(), 1, 10);
            }
            
        }

        public bool InsertWorkerMaster(WorkerMasterResponse workerMaster)
        {
            if (workerMaster == null|| workerMaster.HeadImage==null) { throw new ArgumentNullException("workerMaster/HeadImage is null"); }

            byte[] image = Encoding.UTF8.GetBytes(workerMaster.HeadImage.ToString());

            var obj = new WorkerMaster()
            {
                Id = workerMaster.Id,
                Address = workerMaster.Address,
                WorkerName = workerMaster.WorkerName,
                IDCardType = workerMaster.IDCardType,
                IDCardNumber = workerMaster.IDCardNumber,
                Gender = workerMaster.Gender,
                Nation = workerMaster.Nation,
                Birthday = workerMaster.Birthday,
                BirthPlaceCode = workerMaster.BirthPlaceCode,
                HeadImage = image,
                PoliticsType = workerMaster.PoliticsType,
                IsJoined = workerMaster.IsJoined,
                JoinedTime = workerMaster.JoinedTime,
                CellPhone = workerMaster.CellPhone,
                CultureLevelType = workerMaster.CultureLevelType,
                HasBadMedicalHistory = workerMaster.HasBadMedicalHistory,
                UrgentContractName = workerMaster.UrgentContractName,
                UrgentContractCellphone = workerMaster.UrgentContractCellphone,
                WorkTypeCode = workerMaster.WorkTypeCode,
                WorkDate = workerMaster.WorkDate,
            };
            bool result = _workerMasterRepository.Insert(obj);

            return result;
        }

        public bool UpdateWorkerMaster(WorkerMaster workerMaster)
        {
            if (workerMaster == null) { throw new ArgumentNullException("workerMaster is null"); }

            bool result = _workerMasterRepository.SingleUpdate(workerMaster);

            return result;
        }
    }
}
