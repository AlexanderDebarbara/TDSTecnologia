using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio.Extensoes;

namespace TDSTecnologia.Site.Core.Dominio
{
    public enum DomModalidade
    {
        [EnumDescricao("EAD")]
        EAD,

        [EnumDescricao("Presencial")]
        PRESENCIAL,
    }
}
