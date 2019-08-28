using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio.Extensoes;

namespace TDSTecnologia.Site.Core.Dominio
{
    public enum DomTurno
    {
        [EnumDescricao("Matutino")]
        MATUTINO,

        [EnumDescricao("Vespertino")]
        VESPERTINO,

        [EnumDescricao("Noturno")]
        NOTURNO,

        [EnumDescricao("Integral")]
        INTEGRAL
    }
}
