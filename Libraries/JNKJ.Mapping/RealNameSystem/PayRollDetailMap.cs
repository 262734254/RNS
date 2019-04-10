using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class PayRollDetailMap : EntityTypeConfiguration<PayRollDetail>
    {
        public PayRollDetailMap()
        {
            this.ToTable("PayRollDetail");
            this.HasKey(cr => cr.Id);
        }
    }
}
