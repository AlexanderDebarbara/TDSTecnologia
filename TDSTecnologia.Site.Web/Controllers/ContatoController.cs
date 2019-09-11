using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDSTecnologia.Site.Infrastructure.Integrations.Email;
using TDSTecnologia.Site.Web.ViewModels;

namespace TDSTecnologia.Site.Web.Controllers
{
    
    public class ContatoController : Controller
    {
        private readonly IEmail _email;

        public ContatoController(IEmail email)
        {
            _email = email;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Contatar(ContatoViewModel model)
        {
            await _email.EnviarEmail(model.Email, model.Assunto, model.Mensagem);

            return View(model);
        }
    }
}