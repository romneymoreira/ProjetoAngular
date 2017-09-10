using ProjetoAcessoDados.Base;
using ProjetoAcessoDados.Context;
using ProjetoAcessoDados.Interfaces;
using System;
using System.Web;
using ProjetoAcessoDados.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoAcessoDados.Services
{
    public class CadastroService : RepositoryBase<AppContext>, ICadastroService
    {
        public CadastroService(IUnitOfWork<AppContext> unit)
            : base(unit)
        {
        }

        public Cidade ObterCidadePorId(int idCidade)
        {
            return Context.Cidades.Find(idCidade);
        }

        public List<Cidade> ListarCidadesByEstado(int idEstado)
        {
            return Context.Cidades.Where(x => x.IdEstado == idEstado).ToList();
        }

        public Estado ObterEstadoPorId(int idEstado)
        {
            return Context.Estados.Find(idEstado);
        }
        public List<Estado> ListarEstados()
        {
            return Context.Estados.ToList();
        }

        public Pessoa ObterPessoaPorId(int id)
        {
            return Context.Pessoa.Find(id);
        }
    }
}