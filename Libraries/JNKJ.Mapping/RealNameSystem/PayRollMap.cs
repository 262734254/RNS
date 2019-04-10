using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class PayRollMap : EntityTypeConfiguration<PayRoll>
    {
        public PayRollMap()
        {
            this.ToTable("PayRoll");
            this.HasKey(cr => cr.Id);
        }
    }
}
