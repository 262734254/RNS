﻿using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
    public class TeamMemberMap : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMap()
        {
            this.ToTable("TeamMember");
            this.HasKey(cr => cr.Id);
        }
    }
}
