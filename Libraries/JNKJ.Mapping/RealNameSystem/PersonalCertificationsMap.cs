﻿using JNKJ.Domain.RealNameSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNKJ.Mapping.RealNameSystem
{
   public class PersonalCertificationsMap : EntityTypeConfiguration<PersonalCertifications>
    {
        public PersonalCertificationsMap()
        {
            this.ToTable("PersonalCertifications");
            this.HasKey(cr => cr.Id);
        }
    }
}
