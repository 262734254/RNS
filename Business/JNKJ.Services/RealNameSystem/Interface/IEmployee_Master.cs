using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using System;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 企业信息--从业人员基础信息
    /// </summary>
    public interface IEmployee_Master
    {
        /// <summary>
        /// Get the Employee_Master paged list
        /// </summary>
        /// <param name="birthday">出生日期 : 为空忽略</param>
        /// <param name="employeeName">姓名 : 为空忽略</param>
        /// <param name="cellPhone">手机号码 : 为空忽略</param>
        /// <param name="professionalType">当前职称 : -1时忽略</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        IPagedList<Employee_Master> GetEmployeeMasters(DateTime? birthday, string employeeName = null, string cellPhone = null, int professionalType = -1,
            int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);


        /// <summary>
        ///  Get the Employee_Master by id
        /// </summary>
        /// <param name="employeeMasterId"></param>
        /// <returns></returns>
        Employee_Master GetEmployeeMasterById(Guid employeeMasterId);


        /// <summary>
        /// Insert the Employee_Master
        /// </summary>
        /// <param name="employeeMaster"></param>
        /// <returns></returns>
        bool InsertEmployee_Master(Employee_Master employeeMaster);


        /// <summary>
        /// Updates the Employee_Master
        /// </summary>
        /// <param name="employeeMaster"></param>
        /// <returns></returns>
        bool UpdateEmployee_Master(Employee_Master employeeMaster);


        /// <summary>
        /// Delete the Employee_Master
        /// </summary>
        /// <param name="employeeMaster"></param>
        /// <returns></returns>
        bool DeleteEmployee_Master(Employee_Master employeeMaster);
    }
}
