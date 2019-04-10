using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Systems;

namespace JNKJ.Mapping.Systems
{
    public class ColumnsMap : EntityTypeConfiguration<Columns>
    {
        public ColumnsMap()
        {
            this.ToTable("Columns");
            this.HasKey(c => c.Id);

            this.Property(c => c.ColumnTypeName).HasMaxLength(100);
            this.Property(c => c.ColumnTitle).IsRequired().HasMaxLength(200);
            this.Property(c => c.ColumnKey).IsRequired().HasMaxLength(100);
            this.Property(c => c.ColumnType).IsRequired();
            this.Property(c => c.Subtitle).HasMaxLength(100);
            this.Property(c => c.ActionType).HasMaxLength(50);
            this.Property(c => c.Remark).HasMaxLength(2000);
            this.Property(c => c.ColumnList).HasMaxLength(100);
            this.Property(c => c.SEOKeywords).HasMaxLength(500);
            this.Property(c => c.SEOTitle).HasMaxLength(200);
            this.Property(c => c.LinkUrl).HasMaxLength(100);
            this.Property(c => c.SEODescription).HasMaxLength(500);
            this.Property(c => c.IcoUrl).HasMaxLength(100);
            this.Property(c => c.Creater).HasMaxLength(20);
            this.Property(c => c.Updater).HasMaxLength(20);

        }
    }
}
