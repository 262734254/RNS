using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Customers;
using System.ComponentModel.DataAnnotations.Schema;
namespace JNKJ.Mapping.Customers
{
    public class CustomerExtentionsMap : EntityTypeConfiguration<CustomerExtentions>
    {
        public CustomerExtentionsMap()
        {
            this.ToTable("CustomerExtentions");
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasRequired(c => c.Customer).WithOptional(t => t.CustomerExtentions);

        }
    }
}
