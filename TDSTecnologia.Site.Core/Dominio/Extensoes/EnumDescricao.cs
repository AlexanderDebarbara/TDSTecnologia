using System;
using System.Collections.Generic;
using System.Text;

namespace TDSTecnologia.Site.Core.Dominio.Extensoes
{
    public class EnumDescricao : Attribute
    {
        public string Value { get; private set; }

        public EnumDescricao(string value)
        {
            Value = value;
        }
    }
}
