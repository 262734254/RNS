using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class WorkerGoodRecordsMap : EntityTypeConfiguration<WorkerGoodRecords>
    {
        public WorkerGoodRecordsMap()
        {
            this.ToTable("WorkerGoodRecords");
            this.HasKey(cr => cr.Id);
        }
    }
}

