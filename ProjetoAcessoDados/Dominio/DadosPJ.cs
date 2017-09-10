using ProjetoAcessoDados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class DadosPJ : DomainObject
    {
        public int IdPessoa { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public string InscricaoEstadual { get; protected set; }
        public string InscricaoMunicipal { get; protected set; }
        public DadosPJ(string nomeFantasia,
            string cadastroEspecificoInss,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            SetNomeFantasia(nomeFantasia);
            SetInscricaoEstadual(inscricaoEstadual);
            SetInscricaoMunicipal(inscricaoMunicipal);
        }
        public void SetNomeFantasia(string nomeFantasia)
        {
            Check("NomeFantasia", nomeFantasia)
                 .MaxLength(60);
            this.NomeFantasia = nomeFantasia;
        }

        public void SetInscricaoEstadual(string inscricaoEstadual)
        {
            Check("InscricaoEstadual", inscricaoEstadual)
                 .MaxLength(20);
            this.InscricaoEstadual = inscricaoEstadual;
        }

        public void SetInscricaoMunicipal(string inscricaoMunicipal)
        {
            Check("InscricaoMunicipal", inscricaoMunicipal)
                 .MaxLength(20);
            this.InscricaoMunicipal = inscricaoMunicipal;
        }
    }
}