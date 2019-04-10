using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JNKJ.Mapping.Customers
{
    public class CustomerAttributeMap : EntityTypeConfiguration<CustomerAttribute>
    {
        public CustomerAttributeMap()
        {
            this.ToTable("CustomerAttribute");
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id);
            this.Property(c => c.Gender).HasMaxLength(10);
            this.Property(c => c.FirstName).HasMaxLength(50);
            this.Property(c => c.LastName).HasMaxLength(50);
            this.Property(c => c.DateOfBirth).HasMaxLength(20);
            this.Property(c => c.Company).HasMaxLength(100);
            this.Property(c => c.CompanyAddress).HasMaxLength(200);
            this.Property(c => c.NickName).HasMaxLength(20);
            this.Property(c => c.Avatar).HasMaxLength(100);

            this.HasRequired(c => c.Customer).WithOptional(t => t.CustomerAttribute);
        }
    }
}
