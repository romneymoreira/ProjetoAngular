using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Base
{
    public interface IEntityList
    {
        int Id { get; }
        string DisplayName { get; }
    }
}