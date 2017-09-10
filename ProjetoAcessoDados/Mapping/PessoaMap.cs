using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            this.HasKey(p => p.IdPessoa);

            this.ToTable("pessoa");

            this.HasOptional(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco);

            this.HasOptional(p => p.Contato)
                .WithRequired();

            this.Property(p => p.TipoPessoa)
                .IsRequired();

            this.Property(p => p.CpfCnpj)
                .HasMaxLength(14);

            this.Property(p => p.Cei)
                .HasMaxLength(12);

            this.Property(p => p.Nome)
                .HasMaxLength(120)
                .IsRequired();
        }
    }
}