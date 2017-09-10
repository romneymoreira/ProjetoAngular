using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            this.HasOptional(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco);

            this.HasOptional(p => p.DadosPJ)
                .WithRequired();
        }
    }
}