using System.Linq;
using JNKJ.Services;
using JNKJ.Services.RealNameSystem;
using System.Net.Http;
using System.Web.Http;
using JNKJ.Dto.Enums;

namespace JNKJ.WebAPI.Areas.RNS.Controllers
{
    public class DataDictionaryController : BaseController
    {
        #region Fields

        private readonly IDataDictionary _dataDictionaryService;

        #endregion

        #region Ctor

        public DataDictionaryController(IDataDictionary dataDictionaryService)
        {
            _dataDictionaryService = dataDictionaryService;
        }

        #endregion


        [HttpGet]
        [ActionName("get_dataDictionary")]
        public HttpResponseMessage GetDataDictionary(int pageIndex)
        {
            var result = _dataDictionaryService.GetDataDictionary(pageIndex, ConstKeys.DEFAULT_PAGESIZE);
            return toJson(result);
        }


        [HttpGet]
        [ActionName("get_dictionarysByType")]
        public HttpResponseMessage GetDictionarysByType(string groupKey)
        {
            var list = _dataDictionaryService.GetDictionarysByKey(groupKey).Select(s => new { label = s.SingleOptionValue.ToString(), value = s.SingleOptionLabel.ToString() }).OrderBy(s => s.value);

            return toJson(list, OperatingState.Success, "获取成功");
        }
    }
}
