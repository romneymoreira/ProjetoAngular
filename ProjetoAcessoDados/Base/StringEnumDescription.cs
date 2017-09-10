using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Base
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StringEnumDescription : Attribute
    {
        public readonly string _description;
        public readonly EnumColor _color;

        public StringEnumDescription(string enumDescription)
        {
            this._description = enumDescription;
        }
        public StringEnumDescription(string enumDescription, EnumColor color)
        {
            this._description = enumDescription;
            this._color = color;
        }
    }
}