using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessoDados.Interfaces
{
    public interface IFinanceiroService
    {

        #region [Contas a Receber]
        void SalvarFinanceiro(Financeiro financeiro);
        void ExcluirFinanceiro(Financeiro financeiro);

        ICollection<FinanceiroParcela> ListarContasaReceber();
        ICollection<FinanceiroParcela> ListarContasaReceberAberto();
        ICollection<FinanceiroParcela> ListarContasaReceberBaixado();

        int QuantidadeRegistrosContasaReceber();

        decimal TotalContasaReceber();
        decimal TotalContasaReceberHoje();
        decimal TotalContasaReceberAmanha();
        #endregion

        #region [Contas a Pagar]
        ICollection<FinanceiroParcela> ListarContasaPagar();

        ICollection<FinanceiroParcela> ListarContasaPagarPorId(int id);
        ICollection<FinanceiroParcela> ListarContasaPagarPorCredor(string credor);
        ICollection<FinanceiroParcela> ListarContasaPagarAberto();
        ICollection<FinanceiroParcela> ListarContasaPagarBaixado();
        decimal TotalContasaPagar();
        decimal TotalContasaPagarHoje();
        decimal TotalContasaPagarAmanha();
        #endregion

        #region [Financeiro]
        MeioPagamento GetMeioPagamentoPorId(int id);
        Financeiro ObterFinanceiroPorId(int id);
        FinanceiroParcela ObterFinanceiroParcelaPorId(int id);
        FinanceiroParcela AlterarParcela(FinanceiroParcela parcela);
        ICollection<FinanceiroParcela> ListarParcelasPesquisa(string tipo, string descricao, string tipoConta);
        #endregion

        #region [Cheque]
        void SalvarCheque(Cheque cheque);
        void ExcluirCheque(Cheque cheque);
        Cheque ObterChequePorId(int id);
        ICollection<Cheque> ListarCheques();
        ICollection<Cheque> PesquisarCheques(string emitente, string banco);

        #endregion

        #region [Plano de Conta]
        void SalvarPlanoConta(PlanoConta planoConta);
        void ExcluirPlanoConta(PlanoConta planoConta);
        PlanoConta ObterPlanodeContasPorId(int id);
        ICollection<PlanoConta> ListarPlanoContas();
        ICollection<PlanoConta> PesquisarPlanoContas(string nome, int? codigo, string tipo);
        #endregion

        #region [Banco]
        void SalvarBanco(Banco banco);
        void ExcluirBanco(Banco banco);
        ICollection<Banco> ListarBancos();
        Banco ObterBancoPorId(int id);

        #endregion

        #region [Centro de Custo]
        void SalvarCentroCusto(CentroCusto centroCusto);
        void ExcluirCentroCusto(CentroCusto centroCusto);
        CentroCusto ObterCentroCustoPorId(int id);
        ICollection<CentroCusto> ListarCentroCustos();
        #endregion

        #region [Conta]
        void SalvarConta(Conta conta);
        void ExcluirConta(Conta conta);
        ICollection<Conta> ListarContas();
        ICollection<Conta> PesquisarContas(string nome, int? codigo);
        Conta ObterContaPorId(int id);
        void TransferenciaConta(TransferenciaConta transferenciaConta);

        #endregion

        #region [Caixa Diario]

        void SalvarCaixaDiario(CaixaDiario caixaDiario);
        void ExcluirCaixaDiario(CaixaDiario caixaDiario);
        void SalvarMovimentacaoCaixa(MovimentoCaixa movimentoCaixa);

        #endregion

        #region [MeioPagamento]
        ICollection<MeioPagamento> ListarMeiosdePagamentos();
        MeioPagamento ObterMeioPagamentoPorId(int id);
        #endregion

        #region [Tranferencias entre contas]
        List<TransferenciaConta> GetTransferencias();
        TransferenciaConta GetTransferenciaById(int id);
        void SalvarTransferencia(TransferenciaConta model);
        void ExcluirTransferencia(TransferenciaConta model);
        #endregion
    }
}
