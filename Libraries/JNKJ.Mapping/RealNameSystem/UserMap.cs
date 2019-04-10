using JNKJ.Domain.RealNameSystem;
using System.Data.Entity.ModelConfiguration;

namespace JNKJ.Mapping.RealNameSystem
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(cr => cr.Id);
        }
    }
}
