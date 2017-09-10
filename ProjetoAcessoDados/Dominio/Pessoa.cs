using ProjetoAcessoDados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public abstract class Pessoa : DomainObject
    {
        public int IdPessoa { get; protected set; }
        public int IdEndereco { get; protected set; }
        public string TipoPessoa { get; protected set; }
        public string CpfCnpj { get; protected set; }
        public string Cei { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataCadastro { get; protected set; }

        public virtual Contato Contato { get; protected set; }
        public virtual Endereco Endereco { get; protected set; }

        public virtual ICollection<Financeiro> Financeiros { get; set; }

        protected Pessoa()
        {
            this.DataCadastro = DateTime.Now;
        }

        public void SetCei(string cei)
        {
            this.Cei = cei;
        }

        public void SetCpfProprietario(string cpfProprietario)
        {
            if (!String.IsNullOrEmpty(cpfProprietario))
            {
                cpfProprietario = cpfProprietario.Replace(".", "").Replace("-", "");
                Check("CPF do Proprietário", cpfProprietario)
                    .IsNullOrEmpty()
                    .MaxLength(11)
                    .IsNumber()
                    .IsValidCpf();
            }

        }

        public void SetContato(Contato contato)
        {
            Check("Contato", contato)
                .IsNotNull();
            this.Contato = contato;
        }

        public void SetIdPessoa(int idPessoa)
        {
            IdPessoa = idPessoa;
        }

        public void SetEndereco(Endereco endereco)
        {
            Check("EnderecoDeCorrespondencia", endereco)
                .IsNotNull();
            this.Endereco = endereco;
        }

        public static string FormatarCnpj(string cnpj)
        {
            if (cnpj != null && cnpj.Trim().Length == 14)
                return String.Format("{0:99.999.999/9999-99}", cnpj);
            throw new DomainRuleException("Pessoa", "O CNPJ informado para formatação não é válido");
        }

        public static string FormatarCpf(string cpf)
        {
            if (cpf != null && cpf.Trim().Length == 11)
                return String.Format("{0:999.999.999-99}", cpf);
            throw new DomainRuleException("Pessoa", "O CPF informado para formatação não é válido");
        }

        public static string RemoveMascaraCpfCnpj(string cpfCnpj)
        {
            if (!string.IsNullOrEmpty(cpfCnpj))
                return cpfCnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            throw new DomainRuleException("Pessoa", "Não foi possível remover a máscara CpfCnpj. O valor informado não é válido");
        }
    }
}