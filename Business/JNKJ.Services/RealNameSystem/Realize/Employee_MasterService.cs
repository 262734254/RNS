using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;


namespace JNKJ.Services.RealNameSystem
{
    public class Employee_MasterService : IEmployee_Master
    {
        #region Fields

        private readonly IRepository<Employee_Master> _employeeMasterRepository;

        #endregion

        #region Ctor

        public Employee_MasterService(IRepository<Employee_Master> employeeMasterRepository)
        {
            _employeeMasterRepository = employeeMasterRepository;
        }

        #endregion

        public bool DeleteEmployee_Master(Employee_Master employeeMaster)
        {
            if (employeeMaster == null) { throw new ArgumentNullException("employeeMaster is null"); }

            bool result = _employeeMasterRepository.Delete(employeeMaster);

            return result;
        }

        public Employee_Master GetEmployeeMasterById(Guid employeeMasterId)
        {
            if (Guid.Empty == employeeMasterId) { return null; }

            var customer = _employeeMasterRepository.GetById(employeeMasterId);

            return customer;
        }

        public IPagedList<Employee_Master> GetEmployeeMasters(DateTime? birthday, string employeeName = null, string cellPhone = null, int professionalType = -1, int pageIndex = 1, int pageSize = 100)
        {
            if (pageIndex <= ConstKeys.DEFAULT_PAGEINDEX) { pageIndex = ConstKeys.DEFAULT_PAGEINDEX; }
            if (pageSize >= ConstKeys.DEFAULT_MAX_PAGESIZE || pageSize <= ConstKeys.ZERO_INT) { pageSize = ConstKeys.DEFAULT_PAGESIZE; }

            var query = _employeeMasterRepository.Table;

            if (birthday.HasValue)
            {
                query = query.Where(c => birthday.Value == c.Birthday);
            }
            if (!string.IsNullOrWhiteSpace(employeeName))
            {
                query = query.Where(c => c.EmployeeName.Contains(employeeName));
            }
            if (!string.IsNullOrWhiteSpace(cellPhone))
            {
                query = query.Where(c => c.CellPhone.Contains(cellPhone));
            }
            if (professionalType != -1)
            {
                query = query.Where(c => c.ProfessionalType == professionalType);
            }

            query = query.OrderByDescending(c => c.WorkDate);

            var list = new PagedList<Employee_Master>(query, pageIndex, pageSize);
            return list;
        }

        public bool InsertEmployee_Master(Employee_Master employeeMaster)
        {
            if (employeeMaster == null) { throw new ArgumentNullException("employeeMaster is null"); }

            bool result = _employeeMasterRepository.Insert(employeeMaster);

            return result;
        }

        public bool UpdateEmployee_Master(Employee_Master employeeMaster)
        {
            if (employeeMaster == null) { throw new ArgumentNullException("employeeMaster is null"); }

            bool result = _employeeMasterRepository.SingleUpdate(employeeMaster);

            return result;
        }
    }
}
