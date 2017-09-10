using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class MailTemplate
    {
        public int Id { get; private set; }
        public string Filename { get; private set; }
        public string Folder { get; private set; }
        public string Description { get; private set; }
        public string Subject { get; private set; }
        public string Identifier { get; private set; }

        public MailTemplate()
        {
        }
    }
}