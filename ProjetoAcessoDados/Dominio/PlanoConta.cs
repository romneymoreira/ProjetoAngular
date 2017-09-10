using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class PlanoConta
    {
        public int IdPlanoConta { get; private set; }
        public string NmPlanoConta { get; private set; }
        public string Situacao { get; private set; }
        public string Tipo { get; private set; }
        public string Categoria { get; private set; }
        public string Codigo { get; private set; }

        public virtual ICollection<FinanceiroParcela> Financeiroes { get; set; }

        public PlanoConta()
        {
            this.Financeiroes = new List<FinanceiroParcela>();
        }

        public PlanoConta(string nome, string tipo, string categoria, string codigo)
        {
            SetNomePlanoConta(nome);
            SetSituacao("Ativo");
            SetTipo(tipo);
            SetCodigo(codigo);
            SetCategoria(categoria);
        }

        public void SetNomePlanoConta(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Campo Nome Obrigatório");
            }
            this.NmPlanoConta = nome;

        }

        public void SetSituacao(string situacao)
        {
            if (string.IsNullOrEmpty(situacao))
            {
                throw new Exception("Campo Situação Obrigatório ");
            }
            Situacao = situacao;
        }

        public void SetTipo(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
            {
                throw new Exception("Campo Tipo Obrigatório");
            }
            Tipo = tipo;
        }

        public void SetCategoria(string categoria)
        {
            this.Categoria = categoria;
        }

        public void SetCodigo(string codigo)
        {
            this.Codigo = codigo;
        }

        public void AtivarPlanoConta()
        {
            this.Situacao = "Ativo";
        }

        public void InativarPlanoConta()
        {
            this.Situacao = "Inativo";
        }


    }
}