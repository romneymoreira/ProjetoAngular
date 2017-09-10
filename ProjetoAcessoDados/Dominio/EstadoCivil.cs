using ProjetoAcessoDados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class EstadoCivil : DomainObject, IEntityList
    {
        public int IdEstadoCivil { get; protected set; }
        public string Descricao { get; private set; }

        private EstadoCivil() { }
        public EstadoCivil(int id, string descricao)
        {
            Check("Descricao", descricao)
                .IsNullOrEmpty()
                .MaxLength(30);
            this.IdEstadoCivil = id;
            this.Descricao = descricao;
        }
        public EstadoCivil(string descricao)
        {
            Check("Descricao", descricao)
                .IsNullOrEmpty()
                .MaxLength(30);

            this.Descricao = descricao;
        }

        public int Id
        {
            get { return this.IdEstadoCivil; }
        }

        public string DisplayName
        {
            get { return this.Descricao; }
        }
    }
}