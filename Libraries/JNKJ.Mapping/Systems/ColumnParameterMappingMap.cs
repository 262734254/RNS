using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Systems;

namespace JNKJ.Mapping.Systems
{
    public class ColumnParameterMappingMap : EntityTypeConfiguration<ColumnParameterMapping>
    {
        public ColumnParameterMappingMap()
        {
            this.ToTable("ColumnParameterMapping");
            this.HasKey(c => c.Id);
            this.Property(c => c.ColumnId).IsRequired();
            this.Property(c => c.ParameterId).IsRequired();

        }
    }
}
