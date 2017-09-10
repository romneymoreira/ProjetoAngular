using ProjetoAcessoDados.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProjetoApi.Controllers
{
    [RoutePrefix("cadastro")]
    [Authorize]
    public class CadastroController : BaseController
    {
        private readonly ICadastroService _cadastroService;
        private readonly IUsuarioService _usuarioService;

        public CadastroController(ICadastroService cadastroService, IUsuarioService usuarioService) : base(usuarioService)
        {
            this._cadastroService = cadastroService;
            this._usuarioService = usuarioService;
        }
    }
}