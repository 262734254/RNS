using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Logging;

namespace JNKJ.Mapping.Logging
{
    public partial class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(c => c.Id);
            this.Property(c => c.ShortMessage).IsRequired().HasMaxLength(2000);
            this.Property(c => c.FullMessage).HasMaxLength(8000);
            this.Property(c => c.IpAddress).HasMaxLength(200);
            this.Property(c => c.PageUrl).HasMaxLength(200);
            this.Property(c => c.ReferrerUrl).HasMaxLength(200);
            this.Ignore(c => c.LogLevel);

            this.HasOptional(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
            .WillCascadeOnDelete(true);

        }
    }
}