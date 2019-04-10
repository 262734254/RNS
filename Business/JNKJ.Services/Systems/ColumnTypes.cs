using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Services.Systems
{
    public enum ColumnTypes
    {
        /// <summary>
        /// 系统后台菜单
        /// </summary>
        System = 10,
        /// <summary>
        /// 会员中心导航
        /// </summary>
        Users = 20,
        /// <summary>
        /// 文章栏目
        /// </summary>
        CMS = 30,
        /// <summary>
        /// 商城
        /// </summary>
        Store = 40,
        /// <summary>
        /// 产品
        /// </summary>
        Product = 50,
        /// <summary>
        /// 网站信息
        /// </summary>
        SiteInfo = 100
    }
}
