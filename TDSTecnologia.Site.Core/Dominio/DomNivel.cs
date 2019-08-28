using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio.Extensoes;

namespace TDSTecnologia.Site.Core.Dominio
{
    public enum DomNivel
    {
        [EnumDescricao("Básico")]
        BASICO,

        [EnumDescricao("Intermediário")]
        INTERMEDIARIO,

        [EnumDescricao("Avançado")]
        AVANCADO,
    }
}
