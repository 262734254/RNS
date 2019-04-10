using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
  public  class Company_EmployeMap : EntityTypeConfiguration<Company_Employe>
    {
        public Company_EmployeMap()
        {
            this.ToTable("Company_Employe");
            this.HasKey(cr => cr.Id);
        }
    }
}
