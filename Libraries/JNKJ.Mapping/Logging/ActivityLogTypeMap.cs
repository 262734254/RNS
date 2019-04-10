using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Logging;

namespace JNKJ.Mapping.Logging
{
    public partial class ActivityLogTypeMap : EntityTypeConfiguration<ActivityLogType>
    {
        public ActivityLogTypeMap()
        {
            this.ToTable("ActivityLogType");
            this.HasKey(alt => alt.Id);

            this.Property(alt => alt.SystemKeyword).IsRequired().HasMaxLength(100);
            this.Property(alt => alt.TypeName).IsRequired().HasMaxLength(200);
        }
    }
}
