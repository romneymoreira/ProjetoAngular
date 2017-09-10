using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class BancoMap : EntityTypeConfiguration<Banco>
    {
        public BancoMap()
        {
            this.ToTable("banco");
            // Primary Key
            this.HasKey(t => t.IdBanco);
            this.Property(t => t.NomeBanco).HasColumnName("NmBanco");
            this.Property(t => t.Codigo);
        }
    }
}