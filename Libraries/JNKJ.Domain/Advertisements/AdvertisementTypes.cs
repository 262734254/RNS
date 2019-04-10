using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.Advertisements
{
    /// <summary>
    /// 广告类型的枚举
    /// </summary>
    public enum AdvertisementTypes : int
    {
        /// <summary>
        /// 文字广告
        /// </summary>
        TextAd = 1,
        /// <summary>
        /// 图片广告
        /// </summary>
        Image = 2,
        /// <summary>
        /// 独占轮播广告
        /// </summary>
        Exclusive = 3,
        /// <summary>
        /// 视频/动画广告
        /// </summary>
        Video = 4,
        /// <summary>
        /// 其他类型
        /// </summary>
        Other = 99
    }
}
