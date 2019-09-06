using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDSTecnologia.Site.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
