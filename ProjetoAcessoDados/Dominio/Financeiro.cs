using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Financeiro
    {
        public int IdFinanceiro { get; set; }
        public decimal? TotalDesconto { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalAcerto { get; set; }
        public int IdPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public string Tipo { get; set; }
        public string FormaPagamento { get; set; }
        public virtual ICollection<FinanceiroParcela> Parcelas { get; set; }

        public Financeiro() { }
        public Financeiro(Pessoa pessoa, string tipo, string formaPagamento, ICollection<FinanceiroParcela> parcelas)
        {
            SetPessoa(pessoa);
            SetTipo(tipo);
            SetParcelas(parcelas);
            SetTotal(parcelas);
            SetFormaPagamento(formaPagamento);
        }

        public Financeiro(Pessoa pessoa, string tipo, string formaPagamento)
        {
            SetPessoa(pessoa);
            SetTipo(tipo);
            SetFormaPagamento(formaPagamento);
        }

        public void SetFormaPagamento(string formaPagamento)
        {
            this.FormaPagamento = formaPagamento;
        }

        public void SetTotal(ICollection<FinanceiroParcela> parcelas)
        {
            if (parcelas == null)
            {
                throw new Exception("Nenhuma parcela encontrada");
            }
            this.Total = parcelas.Sum(x => x.Valor);
            this.TotalAcerto = parcelas.Sum(x => x.TotalAcerto);
        }

        public void SetTipo(string tipo)
        {
            this.Tipo = tipo;
        }

        public void SetParcelas(ICollection<FinanceiroParcela> parcelas)
        {
            this.Parcelas = parcelas;
        }

        public void SetPessoa(Pessoa pessoa)
        {
            this.Pessoa = pessoa;
        }

        public void AddParcela(FinanceiroParcela parcela)
        {
            if (this.Parcelas == null)
                this.Parcelas = new Collection<FinanceiroParcela>();
            else if (this.Parcelas.Contains(parcela))
                return;
            //TODO: auditoria usuário inclusão
            this.Parcelas.Add(parcela);

            this.SetTotal(this.Parcelas);
        }

        public void ExcluirParcela(FinanceiroParcela parcela, Usuario usuario)
        {
            if (parcela == null)
                throw new Exception("Nenhuma parcela encontrada");
            else
                parcela.SetSituacao("Excluido");
            parcela.SetUsuarioExclusao(usuario);
            RecalcularFinanceiro();
        }

        public void BaixarConta(FinanceiroParcela parcela, Usuario usuario)
        {
            if (parcela == null)
                throw new Exception("Nenhuma parcela encontrada");
            else

                if (parcela.DataAcerto == null)
            {
                throw new Exception("Campo Data Acerto é Obrigatório ");
            }
            else if (parcela.TotalAcerto == null)
            {
                throw new Exception("Campo Total Acerto é Obrigatório ");
            }
            else if (parcela.MeioPagamento == null)
            {
                throw new Exception("Campo Meio de Pagamento é Obrigatório ");
            }
            parcela.SetSituacao("Baixado");
            parcela.SetUsuarioBaixar(usuario);
            RecalcularFinanceiro();
        }

        public void AlterarConta(FinanceiroParcela parcela, Usuario usuario)
        {
            if (parcela == null)
                throw new Exception("Nenhuma parcela encontrada");
            else
                parcela.SetUsuarioBaixar(usuario);
            RecalcularFinanceiro();
        }

        public void RecalcularFinanceiro()
        {
            this.Total = this.Parcelas.Where(x => x.Situacao != "Excluido").Sum(x => x.Valor);
            this.TotalAcerto = this.Parcelas.Where(x => x.Situacao == "Baixado").Sum(x => x.TotalAcerto);
        }
    }
}