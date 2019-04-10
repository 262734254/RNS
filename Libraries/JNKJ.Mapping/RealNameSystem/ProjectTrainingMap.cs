using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class ProjectTrainingMap : EntityTypeConfiguration<ProjectTraining>
    {
        public ProjectTrainingMap()
        {
            this.ToTable("ProjectTraining");
            this.HasKey(cr => cr.Id);
        }
    }
}
