using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNKJ.Domain;
using JNKJ.Domain.Advertisements;

namespace JNKJ.Services.Advertisements
{
    /// <summary>
    /// 广告
    /// </summary>
    public interface IBannerService
    {
        #region  广告列表
        /// <summary>
        /// 获取广告列表
        /// </summary>
        /// <returns></returns>
        IPagedList<Banner> BannerList(RequestBannerSearch search);
        #endregion

        #region 广告详情
        /// <summary>
        /// 获取广告详情
        /// </summary>
        /// <param name="id">广告ID。</param>
        /// <returns></returns>
        Banner BannerInfo(Guid bannerId);
        #endregion

        #region 添加广告
        /// <summary>
        /// 添加广告
        /// </summary>
        /// <param name="model">广告实体。</param>
        BannerResults AddBanner(Banner model);
        #endregion

        #region 修改广告
        /// <summary>
        /// 修改广告
        /// </summary>
        /// <param name="value">广告实体。</param>
        BannerResults EditBanner(Banner model);
        #endregion

        #region 删除广告
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">广告ID。</param>
        BannerResults DeleteBanner(Guid bannerId);
        #endregion

        #region 显示或隐藏广告
        BannerResults ChangeState(List<Guid> bannerId);
        #endregion

        #region 根据ID批量删除广告
        BannerResults BatchDeleting(List<Guid> ids);
        #endregion

        #region 根据ID批量显示广告
        /// <summary>
        /// 批量显示广告
        /// </summary>
        /// <param name="ids">广告ID集合，用文逗号链接。</param>
        List<Banner> ShowByGuids(List<Guid> ids);

        #endregion
    }
}
