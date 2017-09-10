using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class MeioPagamento
    {
        public MeioPagamento()
        {
            this.FinanceiroParcelas = new Collection<FinanceiroParcela>();
        }
        public int IdMeioPagamento { get; set; }
        public string NmMeioPagamento { get; set; }

        public ICollection<FinanceiroParcela> FinanceiroParcelas { get; set; }
    }
}