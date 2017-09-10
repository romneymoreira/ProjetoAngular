using ProjetoAcessoDados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class DadosPF: DomainObject
    {
        public int IdPessoa { get; private set; }
        public int? IdEstadoCivil { get; private set; }
        public string Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string RG { get; private set; }
        public string NomeMae { get; private set; }
        public string NomePai { get; private set; }
        public Byte[] Foto { get; private set; }
        public virtual EstadoCivil EstadoCivil { get; private set; }

        protected DadosPF() { }

        public DadosPF(DateTime dataNascimento, string sexo, string nomeMae)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.NomeMae = nomeMae;

        }
       
        public DadosPF(DateTime dataNascimento,
                       string rg,
                       string sexo,
                       EstadoCivil estadoCivil,
                       string nomeMae,
                       string numeroDeclaracaoNascVivo)
        {
            SetRG(rg);
            SetEstadoCivil(estadoCivil);
            SetDataNascimento(dataNascimento);
            SetSexo(sexo);
            SetNomeMae(nomeMae);
        }

        public void SetSexo(string sexo)
        {
            Check("Sexo", sexo)
                .IsNotNull();
            this.Sexo = sexo;
        }

        public void SetFoto(Byte[] foto)
        {
            Foto = foto;
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            Check("DataNascimento", dataNascimento)
                .IsValidDateTime();
            this.DataNascimento = dataNascimento;
        }

        public void SetRG(string rg)
        {
            this.RG = rg;
        }
        public void SetIdPessoa(int idPessoa)
        {
            this.IdPessoa = idPessoa;
        }

        public void SetNomeMae(string nomeMae)
        {
            Check("NomeMae", nomeMae)
                .IsNullOrEmpty()
                .MaxLength(400);
            this.NomeMae = nomeMae;
        }

        public void SetNomePai(string nomepai)
        {
            Check("NomePai", nomepai)
                .IsNullOrEmpty()
                .MaxLength(400);
            this.NomePai = nomepai;
        }

        public void SetEstadoCivil(EstadoCivil estadoCivil)
        {
            Check("EstadoCivil", estadoCivil)
              .IsNotNull();
            this.EstadoCivil = estadoCivil;
        }
    }
}