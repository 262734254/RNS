using System.Collections.Generic;
using JNKJ.Domain.RealNameSystem;
using JNKJ.Core.Data;
using System.Linq;
using JNKJ.Domain;
using JNKJ.Dto.Enums;

namespace JNKJ.Services.RealNameSystem
{
    public class DataDictionaryService : IDataDictionary
    {
        #region Fields

        private readonly IRepository<DataDictionary> _dataDictionaryRepository;

        #endregion

        #region Ctor

        public DataDictionaryService(IRepository<DataDictionary> dataDictionaryRepository)
        {
            _dataDictionaryRepository = dataDictionaryRepository;
        }

        #endregion


        /// <summary>
        /// Get the datadictionary paged list
        /// </summary>
        /// <returns></returns>
        public virtual IPagedList<DataDictionary> GetDataDictionary(int pageIndex, int pageSize)
        {
            var query = _dataDictionaryRepository.Table.ToList();

            var list = new PagedList<DataDictionary>(query, pageIndex, pageSize);

            return list;
        }

        public string GetSingleOptionValue(DataDictionaryType type, int singleOptionLabel)
        {
            throw new System.NotImplementedException();
        }


        public IList<DataDictionary> GetDictionarysByKey(string groupKey)
        {
            var query = _dataDictionaryRepository.Table.Where(s => s.GroupKey == groupKey).ToList();
            return query;
        }
    }
}
