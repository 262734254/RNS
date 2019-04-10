using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.Advertisements
{
    public enum LevelTypes : int
    {
        /// <summary>
        /// 四级页面
        /// </summary>
        FourLevel=4,
        /// <summary>
        /// 三级页面
        /// </summary>
        ThreeLevel = 3,
        /// <summary>
        /// 二级页面
        /// </summary>
        TwoLevel = 2,
        /// <summary>
        /// 首页面
        /// </summary>
        HomePage = 1,
        /// <summary>
        /// 全站展示
        /// </summary>
        High = 9
    }
}
