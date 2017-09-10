using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    class DadosPFMap : EntityTypeConfiguration<DadosPF>
    {
        public DadosPFMap()
        {
            this.HasKey(p => p.IdPessoa);

            this.Property(p => p.RG).HasMaxLength(12);
            this.Property(p => p.Sexo)
                .IsRequired();

            this.Property(p => p.NomeMae)
                .HasMaxLength(200);

            this.Property(p => p.NomePai)
               .HasMaxLength(200);

            this.Property(p => p.Foto);

            this.HasOptional(p => p.EstadoCivil)
                .WithMany()
                .HasForeignKey(p => p.IdEstadoCivil);
        }
    }
}