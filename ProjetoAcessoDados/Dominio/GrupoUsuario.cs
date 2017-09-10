using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class GrupoUsuario
    {
        public int IdGrupoUsuario { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Funcionalidade> Funcionalidades { get; set; }

        public GrupoUsuario()
        {
            this.Funcionalidades = new Collection<Funcionalidade>();
        }


    }
}