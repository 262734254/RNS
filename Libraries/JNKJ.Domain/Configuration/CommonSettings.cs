namespace JNKJ.Domain.Configuration
{
    public class CommonSettings : ISettings
    {
        /// <summary>
        /// 使用系统邮箱作为联系方式
        /// </summary>
        public bool UseSystemEmailForContactUsForm { get; set; }
        /// <summary>
        /// 启用线程
        /// </summary>
        public bool UseSitedProceduresIfSupported { get; set; }
        /// <summary>
        /// 隐藏广告
        /// </summary>
        public bool HideAdvertisementsOnAdminArea { get; set; }
        /// <summary>
        /// 启用站点地图
        /// </summary>
        public bool SitemapEnabled { get; set; }
        /// <summary>
        /// 站点地图包含导航
        /// </summary>
        public bool SitemapIncludeCategories { get; set; }
        /// <summary>
        /// 站点地图包含提供商
        /// </summary>
        public bool SitemapIncludeManufacturers { get; set; }
        /// <summary>
        /// 站点地图包含产品
        /// </summary>
        public bool SitemapIncludeProducts { get; set; }
        /// <summary>
        /// 站点地图包含主题
        /// </summary>
        public bool SitemapIncludeTopics { get; set; }

        /// <summary>
        /// 禁用javascript时是否提示
        /// </summary>
        public bool DisplayJavaScriptDisabledWarning { get; set; }

        /// <summary>
        /// 是否支持全文搜索
        /// </summary>
        public bool UseFullTextSearch { get; set; }

        ///// <summary>
        ///// Gets a sets a Full-Text search mode
        ///// </summary>
        //public FulltextSearchMode FullTextMode { get; set; }

        /// <summary>
        /// 404错误时，是否记录错误
        /// </summary>
        public bool Log404Errors { get; set; }

        /// <summary>
        /// 获取或者设置网站使用的分隔符
        /// </summary>
        public string BreadcrumbDelimiter { get; set; }

        /// <summary>
        /// 设置是否要呈现Meta标签  <meta http-equiv="X-UA-Compatible" content="IE=edge"/> tag
        /// </summary>
        public bool RenderXuaCompatible { get; set; }

        /// <summary>
        ///设置是否要呈现Meta标签 "X-UA-Compatible" 
        /// </summary>
        public string XuaCompatibleValue { get; set; }


    }
}