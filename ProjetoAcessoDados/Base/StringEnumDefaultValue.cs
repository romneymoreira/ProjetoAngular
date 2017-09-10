using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Base
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StringEnumDefaultValue : Attribute
    {
    }
}