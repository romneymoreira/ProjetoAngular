﻿using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class PlanoContaMap : EntityTypeConfiguration<PlanoConta>
    {
        public PlanoContaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdPlanoConta);

            // Properties
            this.Property(t => t.NmPlanoConta)
                .HasMaxLength(60);

            // Table & Column Mappings
            this.Property(t => t.IdPlanoConta);
            this.Property(t => t.NmPlanoConta);
            this.Property(t => t.Situacao);
            this.Property(t => t.Categoria).HasColumnName("Categoria");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
        }
    }
}