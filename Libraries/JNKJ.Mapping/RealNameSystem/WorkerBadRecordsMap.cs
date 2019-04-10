using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
    public class WorkerBadRecordsMap : EntityTypeConfiguration<WorkerBadRecords>
    {
        public WorkerBadRecordsMap()
        {
            this.ToTable("WorkerBadRecords");
            this.HasKey(cr => cr.Id);
        }
    }
}