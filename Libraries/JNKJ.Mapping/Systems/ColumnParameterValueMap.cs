using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Systems;

namespace JNKJ.Mapping.Systems
{
    public class ColumnParameterValueMap : EntityTypeConfiguration<ColumnParameterValue>
    {
        public ColumnParameterValueMap()
        {
            this.ToTable("ColumnParameterValue");
            this.HasKey(c => c.Id);

            this.Property(c => c.ParameterId).IsRequired();
            this.Property(c => c.ParamKey).IsRequired().HasMaxLength(100);
            this.Property(c => c.ParamValue).IsRequired().HasMaxLength(100);
            this.Property(c => c.Creater).HasMaxLength(20);

            this.Ignore(c => c.IsChecked);

            this.HasRequired(c => c.Parameters).WithMany(p => p.ParameterValueList).HasForeignKey(c => c.ParameterId);
        }
    }
}
