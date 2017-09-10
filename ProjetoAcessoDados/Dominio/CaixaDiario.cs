using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class CaixaDiario
    {
        public decimal SaldoAbertura { get; set; }
        public decimal SaldoFehamento { get; set; }
        public string SituacaoCaixa { get; set; }
        public DateTime Data { get; set; }
    }
}