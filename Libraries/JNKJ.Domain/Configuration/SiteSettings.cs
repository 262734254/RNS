namespace JNKJ.Domain.Configuration
{
    public class SiteSettings : ISettings
    {
        #region 网站基本信息==================================

        private string _webname = "JNKJ WebSite";
        private string _weburl = "Http://wwww.chingcy.com";
        private string _weblogo = "/styles/images/logo.png";
        private string _webfavicon = "/styles/images/favicon.png";
        private string _webcompany = "深圳清溪科技有限公司";
        private string _shortcompany = "清溪科技";
        private string _webaddress = "深圳市";
        private string _webtel = "400 000 000";
        private string _webfax = "400 000 000";
        private string _webmail = "szqingxi@qq.com";
        private string _webcrod = "";
        private string _webtitle = "";
        private string _webkeyword = "";
        private string _webdescription = "";
        private string _webcopyright = "&copy; 2013 <a target=\"_blank\" href=\"http://www.chingcy.com/\" title=\"深圳清溪科技\">深圳清溪科技</a>. 版权所有. <br> 服务电话：400 000 000  联系邮箱：szqingxi@qq.com";

        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName { get { return _webname; } set { _webname = value; } }
        /// <summary>
        /// 网站域名
        /// </summary>
        public string WebUrl { get { return _weburl; } set { _weburl = value; } }

        /// <summary>
        /// 网站图标
        /// </summary>
        public string WebFavicon { get { return _webfavicon; } set { _webfavicon = value; } }
        /// <summary>
        /// 网站LOGO
        /// </summary>
        public string WebLogo { get { return _weblogo; } set { _weblogo = value; } }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get { return _webcompany; } set { _webcompany = value; } }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ShortCompanyName { get { return _shortcompany; } set { _shortcompany = value; } }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string Address { get { return _webaddress; } set { _webaddress = value; } }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get { return _webtel; } set { _webtel = value; } }
        /// <summary>
        /// 传真号码
        /// </summary>
        public string Fax { get { return _webfax; } set { _webfax = value; } }
        /// <summary>
        /// 管理员邮箱
        /// </summary>
        public string AdminMail { get { return _webmail; } set { _webmail = value; } }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string ICP { get { return _webcrod; } set { _webcrod = value; } }
        /// <summary>
        /// 网站首页标题
        /// </summary>
        public string WebTitle { get { return _webtitle; } set { _webtitle = value; } }
        /// <summary>
        /// 网站版权信息
        /// </summary>
        public string WebCopyright { get { return _webcopyright; } set { _webcopyright = value; } }
        /// <summary>
        /// 在线客服1的代码
        /// </summary>
        public string OnlineCode1 { get; set; }
        /// <summary>
        /// 在线客服2的代码
        /// </summary>
        public string OnlineCode2 { get; set; }
        /// <summary>
        /// 在线客服3的代码
        /// </summary>
        public string OnlineCode3 { get; set; }


        #endregion
    }
}
