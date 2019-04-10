using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class WorkerMasterMap : EntityTypeConfiguration<WorkerMaster>
    {
        public WorkerMasterMap()
        {
            this.ToTable("WorkerMaster");
            this.HasKey(cr => cr.Id);
        }
    }
}
