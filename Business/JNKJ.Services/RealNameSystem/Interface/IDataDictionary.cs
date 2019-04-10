using System.Collections.Generic;
using JNKJ.Domain;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Dto.Enums;

namespace JNKJ.Services.RealNameSystem
{
    /// <summary>
    /// 字典接口
    /// </summary>
    public interface IDataDictionary
    {
        /// <summary>
        /// Get the datadictionary paged list
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<DataDictionary> GetDataDictionary(int pageIndex = ConstKeys.DEFAULT_PAGEINDEX, int pageSize = ConstKeys.DEFAULT_MAX_PAGESIZE);



        /// <summary>
        /// get the value by condition
        /// </summary>
        /// <param name="type">dictionary type</param>
        /// <param name="singleOptionLabel">Value of dictionary type</param>
        /// <returns></returns>
        string GetSingleOptionValue(DataDictionaryType type, int singleOptionLabel);


        /// <summary>
        /// get the dictionarys by groupKey
        /// </summary>
        /// <param name="groupKey"></param>
        /// <returns></returns>
        IList<DataDictionary> GetDictionarysByKey(string groupKey);
    }
}
