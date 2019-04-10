using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Domain.Advertisements
{
    public class Banner:BaseEntity
    {
        /// <summary>
        /// 广告名
        /// </summary>
        public string BannerName { get; set; }
        /// <summary>
        /// 短名
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// 广告描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 点击后跳转的URL
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 分别对应图片/视频/动画的地址
        /// </summary>
        public string BannerUrl { get; set; }
        /// <summary>
        /// 播放时间，只有是动画/视频广告时有用
        /// </summary>
        public int ShowTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 投放类型 2，投放到PC端  1.投放到移动端
        /// </summary>
        public int DeliveryType { get; set; }
        /// <summary>
        /// 广告类型
        /// </summary>
        public int AdvertType { get; set; }
        /// <summary>
        /// 显示位置
        /// </summary>
        public int AdvertPostion { get; set; }
        /// <summary>
        /// 广告层级
        /// </summary>
        public int AdvertLevel { get; set; }
        /// <summary>
        /// 广告排序，越大越靠前
        /// </summary>
        public int SortIndex { get; set; }
        /// <summary>
        /// 状态  0.新增 1.正常 2.审核中 3.隐藏 4.被锁定
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 投放广告的客户ID
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; }
    }
}
