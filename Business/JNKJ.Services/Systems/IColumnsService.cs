using System;
using System.Collections.Generic;
using JNKJ.Domain.Systems;

namespace JNKJ.Services.Systems
{
    public interface IColumnsService
    {
        #region 根据条件获取全部的栏目
        /// <summary>
        /// 获取全部的数据
        /// </summary>
        /// <param name="ColumnType"></param>
        /// <returns></returns>
        IList<Columns> GetColumnsList(ColumnSearch search);
        #endregion

        #region 根据栏目类型和状态获取全部栏目
        /// <summary>
        /// 根据导航的类型，获取下面的全部数据
        /// </summary>
        /// <param name="CategoryType">导航类型</param>
        /// <returns>Customers</returns>
        List<Columns> GetColumnsByType(int columnType, Guid parendId, StatusTypes status = 0, bool? isShow = null, bool? isRecursion = null);
        #endregion

        #region 删除栏目
        /// <summary>
        /// 删除掉一个栏目
        /// </summary>
        /// <param name="Category">栏目的实体</param>
        bool DeleteColumn(Guid columnint);
        #endregion

        #region 根据ID获取栏目实体
        /// <summary>
        /// 根据栏目ID获取一个栏目实体
        /// </summary>
        /// <param name="columnint">栏目的ID</param>
        /// <returns>返回一个栏目实体</returns>
        Columns GetColumnById(Guid columnint, bool isLoad = false);
        #endregion

        #region 获取指定栏目的名字
        string GetColumnName(Guid columnint);
        #endregion

        #region 根据栏目ID数组，获取栏目列表
        /// <summary>
        /// 根据栏目的ID数组，获取对应的实体集合
        /// </summary>
        /// <param name="ColumnIds">栏目的ID数组</param>
        /// <returns>返回栏目的实体集合</returns>
        IList<Columns> GetColumnByIds(Guid[] columnIds);
        #endregion

        #region 根据栏目父ID，获取栏目实体列表
        /// <summary>
        /// 获取所有的父ID为prentId的集合
        /// </summary>
        /// <param name="preantId"></param>
        /// <returns></returns>
        IList<Columns> GetColumnByPrentId(Guid parentId, int status);
        #endregion

        #region 插入一条新数据
        /// <summary>
        /// 插入一个栏目数据
        /// </summary>
        /// <param name="Columns">栏目实体</param>
        bool InsertColumns(Columns column);
        #endregion

        #region 更新一条数据
        /// <summary>
        ///更新一个栏目实体
        /// </summary>
        /// <param name="Category">栏目实体</param>
        bool UpdateColumns(Columns column);
        #endregion

        #region 获取栏目的名称列表
        /// <summary>
        /// 获取栏目的名称列表
        /// </summary>
        /// <param name="Id">要获取的栏目ID</param>
        /// <param name="splitStr">分割字符</param>
        /// <returns></returns>
        string GetFullColumnName(Guid columnint, string splitStr);

        List<Columns> GetFullColumnName(Guid columnint);
        #endregion

        #region 根据条件，判断是否存在相同数据
        /// <summary>
        /// 判断是否存在相同的导航信息
        /// </summary>
        /// <param name="ColumnTitle"></param>
        /// <param name="CategoryType"></param>
        /// <returns></returns>
        bool ExistsColumns(string ColumnTitle, ColumnTypes columnType);
        #endregion

        #region 递归获取所有的栏目
        /// <summary>
        /// 递归获取所有的栏目
        /// </summary>
        /// <param name="CategoryId">栏目ID</param>
        /// <param name="isShowHidden">是否显示隐藏栏目</param>
        /// <returns></returns>
        IList<Columns> GetRecursionColumns(Guid columnId, bool isShowHidden = false);
        #endregion

        #region 判断栏目是否可以删除
        bool IsAllowDelete(Guid columnid);
        #endregion

        #region 根据条件获取栏目的int数组
        Guid[] GetColumns(ColumnSearch search);
        #endregion

        #region 
        Dictionary<Guid, string> GetParentColumns(ColumnTypes type, Guid parentid, bool isShow = false);
        #endregion
    }
}
