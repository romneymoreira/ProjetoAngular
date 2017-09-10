using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Endereco 
    {
        public int IdEndereco { get; private set; } // For EF
        public int IdTipoLogradouro { get; private set; }
        public int IdCidade { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }

        public virtual Cidade Cidade { get; protected set; }

        protected Endereco() { }

        public Endereco(
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cep,
            Cidade cidade)
        {
            if (cep != null)
            {
                cep = cep.Replace("-", "");
                if (cep.Count() != 8)
                    cep = null;
            }

            //Check("Tipo Logradouro", tipoLogradouro)
            //    .IsNotNull();
            //Check("Logradouro", logradouro)
            //    .MaxLength(60);
            //Check("Complemento", complemento)
            //    .MaxLength(20);
            //Check("Bairro", bairro)
            //    .MaxLength(40);
            //Check("CEP", cep)
            //    .ExactLength(8);
            //Check("Cidade", cidade);

            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Cidade = cidade;
        }
    }
}