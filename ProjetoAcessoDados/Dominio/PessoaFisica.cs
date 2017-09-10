using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class PessoaFisica : Pessoa
    {
        #region Propriedades
        public virtual DadosPF DadosPF { get; private set; }
        #endregion

        protected PessoaFisica() { }
        public PessoaFisica(string cpf, string nome)
        {
            SetCpf(cpf);
            SetNome(nome);
            this.TipoPessoa = "PF";
            this.DataCadastro = DateTime.Now;
        }





        public PessoaFisica(string cpf, string nome, DadosPF dadosPf)
            : this(cpf, nome)
        {


            SetDadosPF(dadosPf);

            // Inicia o contato da pessoa fisica.
            if (this.Contato == null)
                this.Contato = new Contato();
        }

        public void SetCpf(string cpf)
        {
            if (!string.IsNullOrEmpty(cpf))
            {
                cpf = cpf.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
                //Check("Cpf", cpf)
                //    .MaxLength(11);

                if (!IsCpfValido(cpf))
                    throw new ArgumentException("O CPF '" + cpf + "' não é válido");
            }
            this.CpfCnpj = cpf;
        }

        public void SetNome(string nome)
        {
            //Check("Nome", nome)
            //    .IsNullOrEmpty();
            this.Nome = nome;
        }

        public void SetDadosPF(DadosPF dadosPf)
        {
            //Check("DadosPF", dadosPf)
            //    .IsNotNull();
            this.DadosPF = dadosPf;
        }

        public static bool IsCpfValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}