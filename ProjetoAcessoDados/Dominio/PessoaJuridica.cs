using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class PessoaJuridica : Pessoa
    {
        public int IdEndereco { get; private set; }

        public string RazaoSocial
        {
            get { return this.Nome; }
        }

        public virtual DadosPJ DadosPJ { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        protected PessoaJuridica() { }
        public PessoaJuridica(string cnpj, string razaoSocial)
        {
            SetCnpj(cnpj);
            SetRazaoSocial(razaoSocial);
            this.TipoPessoa = "PJ";
            this.DataCadastro = DateTime.Now;
        }

        public PessoaJuridica(string cnpj, string razaoSocial, DadosPJ dadosPj)
            : this(cnpj, razaoSocial)
        {
            SetDadosPJ(dadosPj);
        }


        public PessoaJuridica(string cnpj, string razaoSocial, DadosPJ dadosPj, Contato contato)
            : this(cnpj, razaoSocial, dadosPj)
        {
            SetContato(contato);
        }
        public PessoaJuridica(string cnpj, string razaoSocial, DadosPJ dadosPj, string cpfProprietario)
            : this(cnpj, razaoSocial, dadosPj)
        {
            SetCpfProprietario(cpfProprietario);
        }

        public void SetCnpj(string cnpj)
        {
            if (!String.IsNullOrEmpty(cnpj))
            {
                cnpj = cnpj.Replace('.', ' ').Replace('/', ' ').Replace('-', ' ').Replace(" ", "");

                //Check("CNPJ", cnpj)
                //    .IsNullOrEmpty()
                //    .MaxLength(14)
                //    .IsNumber()
                //    .IsValidCnpj();
            }

            this.CpfCnpj = cnpj;
        }

        public void SetRazaoSocial(string razaoSocial)
        {
            //Check("RazaoSocial", razaoSocial)
            //    .IsNullOrEmpty();
            this.Nome = razaoSocial;
        }

        public void SetDadosPJ(DadosPJ dadosPj)
        {
            //Check("DadosPJ", dadosPj)
            //    .IsNotNull();
            this.DadosPJ = dadosPj;
        }

        public void SetEndereco(Endereco endereco)
        {
            //Check("EnderecoDeNotaFiscal", endereco)
            //    .IsNotNull();
            this.Endereco = endereco;
        }


    }
}