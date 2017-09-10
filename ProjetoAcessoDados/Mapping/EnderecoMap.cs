using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            this.HasKey(p => p.IdEndereco);

            this.HasRequired(p => p.Cidade)
                .WithMany()
                .HasForeignKey(p => p.IdCidade);

            this.Property(p => p.Logradouro)
                .HasMaxLength(400)
                .IsRequired();
            this.Property(p => p.Complemento)
                .HasMaxLength(400);
            this.Property(p => p.Numero)
                .IsRequired();
            this.Property(p => p.Bairro)
                .HasMaxLength(400)
                .IsRequired();
            this.Property(p => p.Cep)
                .HasMaxLength(8)
                .IsOptional();

        }
    }
}