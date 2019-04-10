using System.Data.Entity.ModelConfiguration;
using JNKJ.Domain.Customers;

namespace JNKJ.Mapping.Customers
{
    public partial class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(c => c.Id);
            this.Property(u => u.Username).HasMaxLength(50);
            this.Property(u => u.Email).HasMaxLength(1000);
            this.Property(u => u.Mobile).HasMaxLength(20);
            this.Property(u => u.Password).HasMaxLength(200);
            this.Property(u => u.PasswordSalt).HasMaxLength(10);
            this.Property(u => u.RegisterIp).HasMaxLength(30);
            this.Property(u => u.SystemName).HasMaxLength(20);
            this.Property(u => u.LastIpAddress).HasMaxLength(32);
            this.Property(u => u.LastLatitude).HasPrecision(18, 4);
            this.Property(u => u.LastLongitude).HasPrecision(18, 4);

            this.Ignore(u => u.PasswordFormat);

            this.HasMany(c => c.CustomerRoles)
                .WithMany()
                .Map(m => m.ToTable("CustomerRoleMapping"));

            //this.HasOptional(c => c.CustomerExtentions).WithRequired(c => c.Customer);
            //this.HasRequired(a => a.CustomerAttribute).WithMany().HasForeignKey(x =>x.Customerint).WillCascadeOnDelete(false);

            //this.HasMany<Address>(c => c.Addresses)
            //    .WithMany()
            //    .Map(m => m.ToTable("CustomerAddresses"));
            //this.HasOptional<Address>(c => c.BillingAddress);
            //this.HasOptional<Address>(c => c.ShippingAddress);
        }
    }
}