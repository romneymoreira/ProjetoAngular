using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            this.HasOptional(p => p.DadosPF)
                .WithRequired();
        }
    }
}