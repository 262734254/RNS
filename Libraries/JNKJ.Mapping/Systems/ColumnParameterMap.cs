using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Systems;

namespace JNKJ.Mapping.Systems
{
    public class ColumnParameterMap : EntityTypeConfiguration<ColumnParameter>
    {
        public ColumnParameterMap()
        {
            this.ToTable("ColumnParameter");
            this.HasKey(c => c.Id);

            this.Property(c => c.ParameterName).IsRequired().HasMaxLength(100);
            this.Property(c => c.ParameterKey).IsRequired().HasMaxLength(100);
            this.Property(c => c.ParameterType).IsRequired().HasMaxLength(50);
            this.Property(c => c.Creater).HasMaxLength(20);
        }
    }
}
