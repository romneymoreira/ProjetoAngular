using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
   public class EstadoCivilMap : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilMap()
        {
            this.HasKey(p => p.IdEstadoCivil);
            this.Property(p => p.Descricao)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}