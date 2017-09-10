using ProjetoAcessoDados.Base;
using ProjetoAcessoDados.Context;
using ProjetoAcessoDados.Dominio;
using ProjetoAcessoDados.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Services
{
    public class UsuarioService : RepositoryBase<AppContext>, IUsuarioService
    {
        public UsuarioService(IUnitOfWork<AppContext> unit)
            : base(unit)
        {
        }
        public ICollection<Usuario> ListarUsuarios()
        {
            return Context.Usuarios.ToList();
        }

        public Usuario ObterUsuarioPorLogin(string login)
        {
            return Context.Usuarios.Include(x => x.GrupoUsuario).FirstOrDefault(x => x.Login == login);
        }

        public Usuario ObterUsuario(string login, string senha)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Login == login && x.Senha == senha && x.Situacao == "Ativo");
        }

        public Usuario ObterUsuarioPorId(int idusuario)
        {
            return Context.Usuarios.Include(x => x.GrupoUsuario).First(x => x.IdUsuario == idusuario);
        }

        public Usuario SalvarUsuario(Usuario usuario)
        {
            if (usuario.IdUsuario > 0)
            {
                Context.Entry(usuario).State = EntityState.Modified;
            }
            else
            {
                Context.Usuarios.Add(usuario);
            }
            Context.SaveChanges();
            return usuario;
        }

        public void DesativarUsuario(Usuario usuario)
        {
            usuario.Desativar();
            Context.Entry(usuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void AlterarSenha(Usuario usuario, string novasenha)
        {
            usuario.AlterarSenha(novasenha);
            Context.Entry(usuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void ExcluirUsuario(Usuario usuario)
        {
            usuario.Excluir();
            Context.Entry(usuario).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public Usuario ObterUsuarioLogin(string login)
        {
            throw new NotImplementedException();
        }

       
    }
}