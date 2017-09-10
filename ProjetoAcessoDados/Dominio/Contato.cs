using ProjetoAcessoDados.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Contato : DomainObject
    {
        public int IdPessoa { get; private set; }
        public string Email { get; private set; }

        public string Telefone1 { get; private set; }
        public string Telefone2 { get; private set; }
        public string Telefone3 { get; private set; }


        public Contato()
        {
        }


        public void SetEmail(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                //Check("Email", email)
                //    .IsNullOrEmpty()
                //    .MaxLength(40);
            }

            this.Email = email;
        }

      

        public void SetTelefone1(string telefone)
        {
            this.Telefone1 = telefone;
        }

        public void SetTelefone2(string telefone)
        {
            this.Telefone2 = telefone;
        }

        public void SetTelefone3(string telefone)
        {
            this.Telefone3 = telefone;
        }
    }
}