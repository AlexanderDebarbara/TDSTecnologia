using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class AppAbstractController : Controller
    {
        public void AddMensagemAlerta(string msg)
        {
            TempData["_AppMensagemAlerta"] = msg;
        }
        public void AddMensagemErro(string msg)
        {
            TempData["_AppMensagemErro"] = msg;
        }

        public void AddMensagemSucesso(string msg)
        {
            TempData["_AppMensagemSucesso"] = msg;
        }
    }
}