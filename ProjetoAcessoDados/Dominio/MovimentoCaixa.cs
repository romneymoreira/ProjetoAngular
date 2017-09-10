using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class MovimentoCaixa
    {
        public virtual CaixaDiario CaixaDiario { get; set; }
        public string Historico { get; set; }
        public Conta Conta { get; set; }
        public decimal Entrada { get; set; }
        public Financeiro Financeiro { get; set; }
        public decimal Saida { get; set; }
    }
}