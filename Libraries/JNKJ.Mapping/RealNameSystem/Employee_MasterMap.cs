using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class Employee_MasterMap : EntityTypeConfiguration<Employee_Master>
    {
        public Employee_MasterMap()
        {
            this.ToTable("Employee_Master");
            this.HasKey(cr => cr.Id);
        }
    }
}
