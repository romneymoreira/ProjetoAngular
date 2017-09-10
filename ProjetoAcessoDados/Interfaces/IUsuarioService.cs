using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessoDados.Interfaces
{
    public interface IUsuarioService
    {
        Usuario ObterUsuarioPorId(int idUsuario);
        Usuario ObterUsuarioLogin(string login);
        Usuario ObterUsuario(string login, string senha);
        ICollection<Usuario> ListarUsuarios();
        Usuario SalvarUsuario(Usuario usuario);
        void DesativarUsuario(Usuario usuario);
        void ExcluirUsuario(Usuario usuario);
        void AlterarSenha(Usuario usuario, string novasenha);
    }
}
