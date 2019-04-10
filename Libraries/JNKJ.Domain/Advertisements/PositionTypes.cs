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
    public enum PositionTypes : int
    {
        /// <summary>
        /// 顶部展示
        /// </summary>
        Top = 1,
        /// <summary>
        /// 左侧展示
        /// </summary>
        Left = 2,
        /// <summary>
        /// 右侧展示
        /// </summary>
        Right = 3,
        /// <summary>
        /// 位中展示
        /// </summary>
        Middle_Top = 4,
        /// <summary>
        /// 位中展示
        /// </summary>
        Middle = 5,
        /// <summary>
        /// 位中展示
        /// </summary>
        Middle_Botom = 6,
        /// <summary>
        /// 底部展示
        /// </summary>
        Botom = 7,
        /// <summary>
        /// 跟踪悬浮
        /// </summary>
        Suspend = 8,
        /// <summary>
        /// 全屏
        /// </summary>
        FullSreen = 9,
        /// <summary>
        /// 左悬浮
        /// </summary>
        Left_Float=10,
        /// <summary>
        /// 右悬浮
        /// </summary>
        Right_Float=11,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 99
    }
}
