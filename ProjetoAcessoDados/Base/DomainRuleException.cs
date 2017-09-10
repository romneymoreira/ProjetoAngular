using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Base
{
    [Serializable]
    public class DomainRuleException : Exception
    {
        public DomainRuleException()
            : base() { }
        public DomainRuleException(string objectDomainName, string message)
            : base(message, new Exception(string.Format("'{0}': '{1}'", objectDomainName, message)))
        {
        }
        public DomainRuleException(string objectDomainName, string message, params object[] args)
            : this(objectDomainName, string.Format(message, args))
        {
        }
    }
}