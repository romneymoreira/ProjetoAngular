using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }

        public Estado() { }
    }
}