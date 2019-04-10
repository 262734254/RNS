using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Advertisements;

namespace JNKJ.Mapping.Adverts
{
    public class BannerMap : EntityTypeConfiguration<Banner>
    {
        public BannerMap()
        {
            this.ToTable("Banner");
            this.HasKey(s => s.Id);

            this.Property(s => s.BannerName).IsRequired().HasMaxLength(200);
            this.Property(s => s.ShortName).HasMaxLength(100);
            this.Property(s => s.Creater).HasMaxLength(20);
            this.Property(s => s.LinkUrl).HasMaxLength(200);
            this.Property(s => s.BannerUrl).HasMaxLength(1000);
            this.Property(s => s.Description).HasMaxLength(500);
            this.Property(s => s.SortIndex).IsRequired();
            this.Property(s => s.CustomerId).IsRequired();
        }
    }
}
