using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using JNKJ.Core;
using JNKJ.Core.Data;
using JNKJ.Common.Utility;
using JNKJ.Domain.Systems;
using JNKJ.Cache.Caching;
using JNKJ.Domain.Common;
using EntityFramework.Extensions;

namespace JNKJ.Services.Systems
{
    public class ColumnsService : IColumnsService
    {
        #region Constants
        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : 栏目的类型
        /// </remarks>
        private const string COLUMNS_KEY_ID = "JNKJ.COLUMNS.ID-{0}";

        #endregion

        #region Fields

        private readonly IRepository<Columns> _columnsRepository;
        private readonly ICacheManager _cacheManager;
        #endregion

        #region Ctor
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cacheManager"></param>
        /// <param name="columnsRepository"></param>
        /// <param name="eventPublisher"></param>
        public ColumnsService(ICacheManager cacheManager,
            IRepository<Columns> columnsRepository)
        {
            this._cacheManager = cacheManager;
            this._columnsRepository = columnsRepository;
        }
        #endregion

        #region Methods

        #region 根据条件获取全部的栏目
        /// <summary>
        /// 获取全部的数据
        /// </summary>
        /// <param name="ColumnType"></param>
        /// <returns></returns>
        public virtual IList<Columns> GetColumnsList(ColumnSearch search)
        {
            var query = _columnsRepository.Table;
            query = query.Where(c => c.ColumnType == (int)search.columnType);
            //按keys查询
            if (!string.IsNullOrEmpty(search.columnKeys))
            {
                query = query.Where(c => c.ColumnKey == search.columnKeys);
            }
            //按标题查找
            if (!string.IsNullOrEmpty(search.columnTitle))
            {
                query = query.Where(c => c.ColumnTitle.Contains(search.columnTitle) || c.Subtitle.Contains(search.columnTitle));
            }
            if (search.createdFromUtc != DateTime.MinValue)
            {
                //查询的数据不超过一年
                var searchtime = search.createdFromUtc;
                if (search.createdFromUtc.AddYears(1) > DateTime.UtcNow)
                {
                    searchtime = DateTime.UtcNow.AddYears(-1);
                }
                query = query.Where(c => c.CreatedOnUtc >= searchtime);
            }
            //查询时间超过当前时间，默认当前时间
            if (search.createdToUtc != DateTime.MinValue)
            {
                var searchtime = search.createdToUtc;
                if (search.createdToUtc > DateTime.UtcNow)
                {
                    searchtime = DateTime.UtcNow;
                }
                query = query.Where(c => c.CreatedOnUtc >= searchtime);
            }
            //是否读取推荐的栏目
            if (search.IsRecommend > 0)
            {
                query = query.Where(c => c.IsRecommend == search.IsRecommend);
            }
            //是否读取隐藏的栏目
            if (search.isShow > 0)
            {
                query = query.Where(c => c.IsShow == search.isShow);
            }
            if (!string.IsNullOrEmpty(search.parentId.ToString()))
            {
                query = query.Where(c => c.ParentId == search.parentId);
            }
            if (search.isSort)
            {
                query = query.OrderByDescending(c => c.SortIndex);
            }
            query.OrderByDescending(c => c.CreatedOnUtc);

            return query.ToList();
        }

        #endregion

        #region 根据栏目类型和状态获取全部栏目
        /// <summary>
        /// 根据导航的类型，获取下面的全部数据
        /// </summary>
        /// <param name="CategoryType">导航类型</param>
        /// <returns>Customers</returns>
        public List<Columns> GetColumnsByType(int columnType, Guid parendId, StatusTypes status = ConstKeys.ZERO_INT, bool? isShow = default(bool?), bool? isRecursion = default(bool?))
        {
            var query = _columnsRepository.Table.Where(c => c.ColumnType == columnType);
            if (status > 0)
            {
                int _status = (int)status;
                query = query.Where(c => c.Status == _status);
            }
            if (isShow != null && isShow == true)
            {
                query = query.Where(c => c.IsShow == ConstKeys.ENABLE);
            }
            if (isRecursion != null && isRecursion == false)
            {
                return query.ToList();
            }
            var list = query.ToList();
            var newlist = new List<Columns>();
            GetChilds(newlist, list, parendId);
            return newlist;

        }

        #endregion

        #region 删除栏目
        /// <summary>
        /// 删除掉一个栏目
        /// </summary>
        /// <param name="Category">栏目的实体</param>
        public virtual bool DeleteColumn(Guid columnid)
        {
            var column = _columnsRepository.Table.Where(c => c.Id == columnid).FirstOrDefault();
            if (column == null)
                return false;

            if (column.IsSystem == (int)StatusTypes.Normal)
                throw new ExceptionExt(string.Format("System Column  ({0},Id:{1}) could not be deleted", column.ColumnTitle, column.Id));

            string keys = "," + column.Id + ",";
            int state = (int)StatusTypes.Deleted;
            //批量更新
            _columnsRepository.Table.Where(c => c.ColumnList.Contains(keys) || c.Id == columnid)
                .Update(t => new Columns { Status = state });

            string key = string.Format(COLUMNS_KEY_ID, columnid.ToString());
            _cacheManager.RemoveByPattern(key);

            if (_columnsRepository.SaveChanges())
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 根据ID获取栏目实体
        /// <summary>
        /// 根据栏目ID获取一个栏目实体
        /// </summary>
        /// <param name="columnint">栏目的ID</param>
        /// <returns>返回一个栏目实体</returns>
        public virtual Columns GetColumnById(Guid columnint, bool isLoad = false)
        {
            if (string.IsNullOrEmpty(columnint.ToString()))
                return null;

            var model = _columnsRepository.Table.Where(c => c.Id == columnint).FirstOrDefault();
            if (model != null && isLoad)
            {
                //var category = _columnsRepository.Context.Entry<Columns>(model);
                //category.Collection(c => c.ParametersMapping).Load();
            }
            return model;
        }
        #endregion

        #region 获取指定栏目的名字
        public string GetColumnName(Guid columnint)
        {
            if (string.IsNullOrEmpty(columnint.ToString()))
                return string.Empty;
            return _columnsRepository.Table.Where(c => c.Id == columnint).Select(c => c.ColumnTitle).FirstOrDefault().ToString();
        }
        #endregion

        #region 根据栏目ID数组，获取栏目列表
        /// <summary>
        /// 根据栏目的ID数组，获取对应的实体集合
        /// </summary>
        /// <param name="ColumnIds">栏目的ID数组</param>
        /// <returns>返回栏目的实体集合</returns>
        public virtual IList<Columns> GetColumnByIds(Guid[] columnIds)
        {
            if (columnIds == null || columnIds.Length == 0)
                return new List<Columns>();

            var query = from c in _columnsRepository.Table
                        where columnIds.Contains(c.Id)
                        select c;
            var column = query.ToList();

            return column;
        }
        #endregion

        #region 根据栏目父ID，获取栏目实体列表
        /// <summary>
        /// 获取所有的父ID为prentId的集合
        /// </summary>
        /// <param name="preantId"></param>
        /// <returns></returns>
        public virtual IList<Columns> GetColumnByPrentId(Guid parentId, int status)
        {
            var query = _columnsRepository.Table.Where(c => c.ParentId == parentId);
            if (status != 0)
            {
                query = query.Where(c => c.Status == (int)StatusTypes.Normal);
            }
            return query.ToList();
        }
        #endregion

        #region 插入一条新数据
        /// <summary>
        /// 插入一个栏目数据
        /// </summary>
        /// <param name="Columns">栏目实体</param>
        public virtual bool InsertColumns(Columns column)
        {
            if (column == null)
                return false;
            bool result = _columnsRepository.Insert(column);

            if (result)
            {
                string key = string.Format(COLUMNS_KEY_ID, column.Id);
                _cacheManager.Set(key, column, ConstKeys.CACHETIME);
                //event notification
                return true;

            }
            return false;
        }
        #endregion

        #region 更新一条数据
        /// <summary>
        ///更新一个栏目实体
        /// </summary>
        /// <param name="Category">栏目实体</param>
        public virtual bool UpdateColumns(Columns column)
        {
            if (column == null)
                throw new ExceptionExt("Columns is null");

            bool result = _columnsRepository.Update(column);

            if (result)
            {
                var list = GetColumnByPrentId(column.Id, 0);
                foreach (var m in list)
                {
                    m.ColumnList = column.ColumnList + m.Id + ",";
                    m.ColumnLayer = column.ColumnLayer++;
                    UpdateColumns(m);
                }
                string key = string.Format(COLUMNS_KEY_ID, column.Id);
                _cacheManager.RemoveByPattern(key);
            }
            return result;
        }
        #endregion

        #region 获取栏目的名称列表
        /// <summary>
        /// 获取栏目的名称列表
        /// </summary>
        /// <param name="Id">要获取的栏目ID</param>
        /// <param name="splitStr">分割字符</param>
        /// <returns></returns>
        public string GetFullColumnName(Guid columnId, string splitStr)
        {
            if (string.IsNullOrEmpty(columnId.ToString()))
                return string.Empty;
            var column = _columnsRepository.Table.Where(c => c.Id == columnId).FirstOrDefault();
            if (column == null) return string.Empty;
            var columnList = StrTools.DelFAChar(column.ColumnList, ",");
            Guid[] lArray = columnList.Split(',').Select(s => Guid.Parse(s)).ToArray();
            var list = _columnsRepository.Table.Where(c => lArray.Contains(c.Id)).ToList();
            string Categorystr = "";
            foreach (var m in list)
            {
                if (list.IndexOf(m) == 0)
                { Categorystr += m.ColumnTitle; }
                else
                { Categorystr += splitStr + m.ColumnTitle; }

            }
            return Categorystr;
        }

        public List<Columns> GetFullColumnName(Guid columnint)
        {
            List<Columns> list = new List<Columns>();
            if (string.IsNullOrEmpty(columnint.ToString())) return list;
            var column = _columnsRepository.Table.Where(c => c.Id == columnint).FirstOrDefault();
            if (column == null) return list;
            var columnList = StrTools.DelFAChar(column.ColumnList, ",");
            Guid[] lArray = columnList.Split(',').Select(s => Guid.Parse(s)).ToArray();
            var _list = _columnsRepository.Table.Where(c => lArray.Contains(c.Id)).ToList();

            foreach (var m in _list)
            {
                list.Add(m);
            }
            return list;
        }
        #endregion

        #region 根据条件，判断是否存在相同数据
        /// <summary>
        /// 判断是否存在相同的导航信息
        /// </summary>
        /// <param name="ColumnTitle"></param>
        /// <param name="CategoryType"></param>
        /// <returns></returns>
        public virtual bool ExistsColumns(string ColumnTitle, ColumnTypes columnType)
        {
            if (string.IsNullOrWhiteSpace(ColumnTitle))
                throw new ExceptionExt("Column Name Is Null");
            var query = _columnsRepository.Table.Where(c => c.ColumnTitle == ColumnTitle && c.ColumnType == (int)columnType);
            return query.Count() > 0 ? true : false;
        }
        #endregion

        #region 递归获取所有的栏目
        /// <summary>
        /// 递归获取所有的栏目
        /// </summary>
        /// <param name="CategoryId">栏目ID</param>
        /// <param name="isShowHidden">是否显示隐藏栏目</param>
        /// <returns></returns>
        public virtual IList<Columns> GetRecursionColumns(Guid columnId, bool isShowHidden = false)
        {
            var list = new List<Columns>();
            if (string.IsNullOrEmpty(columnId.ToString())) return list;
            string tree = "," + columnId + ",";
            var query = _columnsRepository.Table.Where(c => c.Id == columnId || c.ColumnList.Contains(tree));
            query = query.Where(c => c.Status == (int)StatusTypes.Normal);
            if (!isShowHidden)
                query = query.Where(c => c.IsShow == (int)StatusTypes.Normal);
            return query.ToList();
        }

        private void GetChilds(IList<Columns> list, IList<Columns> olddata, Guid parentid)
        {
            var sub = olddata.Where(c => c.ParentId == parentid);
            foreach (var m in sub)
            {
                //添加一行数据
                list.Add(m);
                //调用自身迭代
                this.GetChilds(list, olddata, m.Id);
            }
        }
        #endregion

        #region 判断栏目是否可以删除
        public virtual bool IsAllowDelete(Guid columnid)
        {
            var query = _columnsRepository.Table;
            string filedstr = string.Format(",{0},", columnid);
            int count = query.Where(c => c.ColumnList.Contains(filedstr) && c.ParentId != null).Select(c => c.Id).Count();
            if (count > 0) return false;
            return true;
        }
        #endregion

        #region 根据条件获取栏目的id数组
        public Guid[] GetColumns(ColumnSearch search)
        {

            var query = _columnsRepository.Table;

            query = query.Where(c => (int)search.columnType == c.ColumnType);

            if (!string.IsNullOrWhiteSpace(search.columnTitle))
                query = query.Where(c => c.ColumnTitle.Contains(search.columnTitle));

            if (!string.IsNullOrWhiteSpace(search.columnKeys))
                query = query.Where(c => c.ColumnKey.Contains(search.columnKeys));

            if (search.createdFromUtc != DateTime.MinValue)
                query = query.Where(c => search.createdFromUtc <= c.CreatedOnUtc);

            if (search.createdFromUtc != DateTime.MinValue)
                query = query.Where(c => search.createdFromUtc >= c.CreatedOnUtc);

            if (!string.IsNullOrEmpty(search.parentId.ToString()))
            {
                string tree = "%," + search.parentId + ",%";
                query = query.Where(c => c.Id == search.parentId || tree.Contains(c.ColumnList));
            }


            if (search.Status != ConstKeys.IGNORE)
                query = query.Where(c => (int)search.Status == c.Status);

            if (search.isShow != ConstKeys.IGNORE)
                query = query.Where(c => c.IsShow == search.isShow);

            if (search.IsRecommend != ConstKeys.IGNORE)
                query = query.Where(c => c.IsRecommend == search.IsRecommend);

            if (search.isSort)
            {
                query = query.OrderByDescending(c => c.SortIndex);
            }
            else
            {
                query = query.OrderByDescending(c => c.CreatedOnUtc);
            }

            var ids = query.Select(c => c.Id).ToArray();
            return ids;
        }

        #endregion

        #region 获取栏目的名称和ID
        /// <summary>
        /// 获取父节点的名称和ID
        /// 只取2级
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parentid"></param>
        /// <param name="isShow"></param>
        /// <returns></returns>
        public Dictionary<Guid, string> GetParentColumns(ColumnTypes columnType, Guid parentid, bool isShow = false)
        {
            var query = _columnsRepository.Table;
            query = query.Where(c => c.ColumnType == (int)columnType);
            string key = string.Format(",{0},", parentid);
            if (!string.IsNullOrEmpty(parentid.ToString()))
                query = query.Where(c => c.ColumnList.Contains(key));
            if (!isShow)
                query = query.Where(c => c.Status == (int)StatusTypes.Normal);

            query = query.OrderBy(c => c.CreatedOnUtc);
            var list = query.ToList();
            Dictionary<Guid, string> dic = new Dictionary<Guid, string>();
            list.Where(c => c.ParentId == parentid).ToList().ForEach(m =>
            {
                dic.Add(m.Id, m.ColumnTitle);
                var subdic = query.Where(c => c.ParentId == m.Id).Select(model => new { id = model.Id, name = model.ColumnTitle })
                .ToDictionary(c => c.id, c => c.name);
                foreach (var dt in subdic)
                {
                    dic.Add(dt.Key, dt.Value);
                }
            });
            return dic;
        }
        #endregion
        #endregion
    }
}
