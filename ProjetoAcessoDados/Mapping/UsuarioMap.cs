using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.IdUsuario);

            this.Property(t => t.Nome)
                .IsRequired();

            this.Property(t => t.Login)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.Senha)
                .IsRequired();

            this.Property(t => t.Situacao)
                .IsRequired();

            // Relationships
            this.HasRequired(t => t.GrupoUsuario)
                .WithMany(t => t.Usuarios)
                .HasForeignKey(d => d.IdGrupoUsuario);
        }
    }
}