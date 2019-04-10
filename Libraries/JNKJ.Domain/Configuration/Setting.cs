namespace JNKJ.Domain.Configuration
{
    /// <summary>
    /// 设置
    /// </summary>
    public partial class Setting : BaseEntity
    {
        public Setting() { }

        public Setting(string name, string value, int SiteId = 0)
        {
            this.Name = name;
            this.Value = value;
            this.SiteId = SiteId;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 关联的站点ID
        /// </summary>
        public int SiteId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
