using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class DadosPJMap : EntityTypeConfiguration<DadosPJ>
    {
        public DadosPJMap()
        {
            this.HasKey(p => p.IdPessoa);

            this.Property(p => p.NomeFantasia).HasMaxLength(60);
            this.Property(p => p.InscricaoEstadual).HasMaxLength(20);
            this.Property(p => p.InscricaoMunicipal).HasMaxLength(20);

        }
    }
}