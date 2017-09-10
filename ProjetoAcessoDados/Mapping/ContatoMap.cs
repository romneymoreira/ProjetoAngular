using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            this.HasKey(p => p.IdPessoa);

            this.Property(p => p.Telefone1);
            this.Property(p => p.Telefone2);
            this.Property(p => p.Telefone3);

            this.Property(p => p.Email)
                .HasMaxLength(40);
        }
    }
}