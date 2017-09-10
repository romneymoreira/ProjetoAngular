using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Modulo
    {

        public int IdModulo { get; set; }
        public string NmModulo { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<Funcionalidade> Funcionalidades { get; set; }

        public Modulo()
        {
            this.Funcionalidades = new Collection<Funcionalidade>();
        }
    }
}