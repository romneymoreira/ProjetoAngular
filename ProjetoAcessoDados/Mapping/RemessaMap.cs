﻿using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class RemessaMap : EntityTypeConfiguration<Remessa>
    {
        public RemessaMap()
        {
            // Primary Key
            this.HasKey(t => t.IdRemessa);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}