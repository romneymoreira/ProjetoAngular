using ProjetoAcessoDados.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Interfaces
{
    public interface ICadastroService
    {
        #region [Pessoa]
        Pessoa ObterPessoaPorId(int id);
        #endregion

        #region [Estado - Cidade]
        Estado ObterEstadoPorId(int idEstado);
        Cidade ObterCidadePorId(int idCidade);
        List<Cidade> ListarCidadesByEstado(int idEstado);
        List<Estado> ListarEstados();
        #endregion
    }
}